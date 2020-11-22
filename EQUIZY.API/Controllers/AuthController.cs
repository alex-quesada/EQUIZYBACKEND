using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EQUIZY.API.JWTSettings;
using EQUIZY.API.Resources;
using EQUIZY.API.Services;
using EQUIZY.Core.Models;
using EQUIZY.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EQUIZY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly MyEquizyDbContext _context;
        private readonly string container = "profiles";
        private readonly JwtSettings _jwtSettings;

        public AuthController(IMapper mapper, 
            UserManager<AppUser> userManager, 
            RoleManager<AppUserRole> roleManager,
            IOptionsSnapshot<JwtSettings> jwtSettings,
            IAlmacenadorArchivos almacenadorArchivos,
            MyEquizyDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _context = context;
            _almacenadorArchivos = almacenadorArchivos;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
        {
            var user = _mapper.Map<UserSignUpResource, AppUser>(userSignUpResource);
            var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);
            if (userCreateResult.Succeeded)
            {
                await AddUserToRole(userSignUpResource.Email, userSignUpResource.RoleName);
                return Created(string.Empty, string.Empty);
            }
            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
        {
            var appUser = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Email);
            if (appUser is null)
            {
                return NotFound("Usuario no encontrado");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(appUser, userLoginResource.Password);

            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(appUser);
                return Ok(GenerateJwt(appUser, roles));
            }

            return BadRequest("Email o contraseña incorrect@.");
        }
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("El nombre del rol es requerido.");
            }
            var newRole = new AppUserRole
            {
                Name = roleName
            };
            var roleResult = await _roleManager.CreateAsync(newRole);
            if (roleResult.Succeeded)
            {
                return Ok();
            }

            return Problem(roleResult.Errors.First().Description, null, 500);
        }
        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }
        private string GenerateJwt(AppUser appUser, IList<string> appRoles)
        {
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, appUser.Id.ToString()),
        new Claim(ClaimTypes.Name, appUser.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString())
    };

            var roleClaims = appRoles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("userbytoken")]
        public async Task<ActionResult> Get()
        {
            var token = Request.Headers["Authorization"].ToString();
            var user = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = new Guid(user.Claims.ToArray()[0].Value.ToString());
            var foundUser = await _userManager.Users.SingleOrDefaultAsync(m => m.Id == userId);
            if (foundUser == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<AppUser, AppUserResource>(foundUser));
        }
        [HttpPut("update")]
        public async Task<ActionResult> Put([FromBody] AppUserUpdateResource appUserUpdate)
        {
            var token = Request.Headers["Authorization"].ToString();
            var user = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = new Guid(user.Claims.ToArray()[0].Value.ToString());
            var userToUpdate = await _userManager.Users.SingleOrDefaultAsync(a => a.Id == userId);
            if (userToUpdate == null) { return NotFound(); }
            userToUpdate.FirstName = appUserUpdate.FirstName;
            userToUpdate.SecondName = appUserUpdate.SecondName;
            userToUpdate.LastName = appUserUpdate.LastName;
            userToUpdate.SecondLastName = appUserUpdate.SecondLastName;
            userToUpdate.Telephone = appUserUpdate.Telephone;
            userToUpdate.DateOfBirth = appUserUpdate.DateOfBirth;
            userToUpdate.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.UpdateAsync(userToUpdate);
            await _context.SaveChangesAsync();
            return Ok(userToUpdate);
        }
        [HttpPost("foto")]
        public async Task<ActionResult> Post([FromForm] AddingUserFoto addingUserFoto)
        {
            var img = Request.Form.Files.First();
            var token = Request.Headers["Authorization"].ToString();
            var user = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = new Guid(user.Claims.ToArray()[0].Value.ToString());
            AppUser userWithFoto = await _userManager.Users.SingleOrDefaultAsync(m => m.Id == userId);
            if (userWithFoto.Image == null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await img.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(img.FileName);
                    userWithFoto.Image = await _almacenadorArchivos.GuardarArchivo(content, extension,
                        container, img.ContentType);
                }
                await _context.SaveChangesAsync();
                if (userWithFoto.Image != null)
                {
                    userWithFoto.PasswordHash = null;
                    return Ok(userWithFoto);
                }
                return BadRequest();
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    await img.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(img.FileName);
                    userWithFoto.Image = await _almacenadorArchivos.EditarArchivo(content, extension,
                        container, userWithFoto.Image, img.ContentType);
                }
                await _context.SaveChangesAsync();
                if (userWithFoto.Image != null)
                {
                    userWithFoto.PasswordHash = null;
                    return Ok(userWithFoto);
                }
                return BadRequest();
            }

        }
    }
}
