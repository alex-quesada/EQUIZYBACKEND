using AutoMapper;
using EQUIZY.API.Resources;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ICityService _cityService;
        private readonly IUserAddressListService _userAddressListService;
        private readonly ITypeAddressService _typeAddressService;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService,
            ICityService cityService,
            IUserAddressListService userAddressListService,
            ITypeAddressService typeAddressService,
            ICountryService countryService,
            IStateProvinceService stateProvinceService,
        IMapper mapper)
        {
            _addressService = addressService;
            _cityService = cityService;
            _userAddressListService = userAddressListService;
            _typeAddressService = typeAddressService;
            _countryService = countryService;
            _stateProvinceService = stateProvinceService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<AddressInfoResource>> GetAllAddresses()
        {
            var result = new AddressInfoResource();
            var token = Request.Headers["Authorization"].ToString();
            var user = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = user.Claims.ToArray()[0].Value.ToString();
            var userGuid = new Guid(userId);
            var addresses = await _addressService.GetAllWithCity(userGuid);
            var typesAddress = await _typeAddressService.GetAllTypeAddress();
            var countries = await _countryService.GetAllCountries();
            result.CountriesListDTO = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
            result.TypeAddressesDTO = _mapper.Map<IEnumerable<TypeAddress>, IEnumerable<TypeAddressResource>>(typesAddress);
            result.AddressesListDTO = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(addresses);
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressResource>> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            var countryResource = _mapper.Map<Address, AddressResource>(address);
            return Ok(countryResource);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<SaveAddressResource>> CreateCountry([FromBody] SaveAddressResource saveAddressResource)
        {
            var address = _mapper.Map<SaveAddressResource, Address>(saveAddressResource);
            address.TypeAddress = await _typeAddressService.GetTypeAddressById(saveAddressResource.TypeAddressId);
            var city = await _cityService.GetCityByName(saveAddressResource.CityName);
            var stateProvince = await _stateProvinceService.GetStateProvinceById(saveAddressResource.StateId);
            if (city != null && city.StateProvinceId == stateProvince.Id)
            {
                address.City = city;
                address.CityId = city.Id;
            }
            else
            {
                var cityToAdd = new City();
                cityToAdd.Name = saveAddressResource.CityName;
                cityToAdd.StateProvinceId = saveAddressResource.StateId;
                var cityAdded = await _cityService.CreateCity(cityToAdd);
                address.City = cityAdded;
                address.CityId = cityAdded.Id;
            }
            address.Status = 1;
            var addressAdded = await _addressService.CreateAddress(address);
            var addressCreated = await _addressService.GetAddressById(addressAdded.Id);
            var token = Request.Headers["Authorization"].ToString();
            var user = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = new Guid(user.Claims.ToArray()[0].Value.ToString());
            var userAddresListItem = new UserAddressList();
            userAddresListItem.UserId = userId;
            userAddresListItem.AddressId = addressCreated.Id;
            userAddresListItem.Status = 1;
            var addressListItemCreated = await _userAddressListService.CreateUserAddressListItem(userAddresListItem);
            if (addressListItemCreated == null)
            {
                BadRequest();
            }
            var addressResource = _mapper.Map<Address, AddressResource>(addressCreated);
            return Ok(addressResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressResource>> UpdateAddress(int id, [FromBody] SaveAddressResource saveAddressResource)
        {
            var addressToUpdate = await _addressService.GetAddressById(id);
            if (addressToUpdate == null)
            {
                return NotFound();
            }
            var address = _mapper.Map<SaveAddressResource, Address>(saveAddressResource);
            var city = await _cityService.GetCityByName(saveAddressResource.CityName);
            var stateProvince = await _stateProvinceService.GetStateProvinceById(saveAddressResource.StateId);
            if (city != null && city.StateProvinceId == stateProvince.Id)
            {
                address.City = city;
                address.CityId = city.Id;
            }
            else
            {
                var cityToAdd = new City();
                cityToAdd.Name = saveAddressResource.CityName;
                cityToAdd.StateProvinceId = saveAddressResource.StateId;
                var cityAdded = await _cityService.CreateCity(cityToAdd);
                address.City = cityAdded;
                address.CityId = cityAdded.Id;
            }
            await _addressService.UpdateAddress(addressToUpdate, address);
            var addressUpdated = await _addressService.GetAddressById(id);
            var addressResource = _mapper.Map<Address, AddressResource>(addressUpdated);
            return Ok(addressResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var addressToDelete = await _addressService.GetAddressById(id);
            var addressListToDelete = await _userAddressListService.GetUserAddressListByAddressId(id);
            await _addressService.DeleteAddress(addressToDelete);
            await _userAddressListService.DeleteUserAddressListItem(addressListToDelete);
            return NoContent();
        }
    }
}
