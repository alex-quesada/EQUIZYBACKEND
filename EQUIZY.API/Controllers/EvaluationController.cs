using AutoMapper;
using EQUIZY.API.Resources;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITopicEvaluationService _topicEvaluationService;
        private readonly ITypeEvaluationService _typeEvaluationService;
        private readonly ICategoryEvaluationService _categoryEvaluationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEvaluationService _evaluationService;
        private readonly IProfessorProfessorEvaluationListService _professorProfessorEvaluationListService;

        public EvaluationController(IMapper mapper, 
            ITopicEvaluationService topicEvaluationService, 
            ITypeEvaluationService typeEvaluationService, 
            ICategoryEvaluationService categoryEvaluationService,
            UserManager<AppUser> userManager,
            IEvaluationService evaluationService,
            IProfessorProfessorEvaluationListService professorProfessorEvaluationListService)
        {
            _mapper = mapper;
            _topicEvaluationService = topicEvaluationService;
            _typeEvaluationService = typeEvaluationService;
            _categoryEvaluationService = categoryEvaluationService;
            _userManager = userManager;
            _evaluationService = evaluationService;
            _professorProfessorEvaluationListService = professorProfessorEvaluationListService;
        }
        [HttpGet("data")]
        public async Task<ActionResult<EvaluationInfoResource>> GetData1()
        {
            var data = new EvaluationInfoResource();
            data.TopicsEvaluation = _mapper.Map<
                IEnumerable<TopicEvaluation>, List<TopicEvaluationResource>>(
                await _topicEvaluationService.GetAllTopicEvaluation());
            data.CategoriesEvaluation = _mapper.Map<
                IEnumerable<CategoryEvaluation>, List<CategoryEvaluationResource>>(
                await _categoryEvaluationService.GetAllCategoryEvaluation());
            data.TypesEvaluation = _mapper.Map<
                IEnumerable<TypeEvaluation>, List<TypeEvaluationResource>>(
                await _typeEvaluationService.GetAllTypeEvaluation());
            return data;
        }
        [HttpGet("evals")]
        public async Task<ActionResult<EvaluationDataResource>> GetData2()
        {
            var token = Request.Headers["Authorization"].ToString();
            var userToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = userToken.Claims.ToArray()[0].Value.ToString();
            var userGuid = new Guid(userId);
            var data = new EvaluationDataResource();
            data.TopicsEvaluation = _mapper.Map<
                IEnumerable<TopicEvaluation>, List<TopicEvaluationResource>>(
                await _topicEvaluationService.GetAllTopicEvaluation());
            data.CategoriesEvaluation = _mapper.Map<
                IEnumerable<CategoryEvaluation>, List<CategoryEvaluationResource>>(
                await _categoryEvaluationService.GetAllCategoryEvaluation());
            data.TypesEvaluation = _mapper.Map<
                IEnumerable<TypeEvaluation>, List<TypeEvaluationResource>>(
                await _typeEvaluationService.GetAllTypeEvaluation());
            data.Evaluations = _mapper.Map<
                IEnumerable<Evaluation>, List<EvaluationResource>>(
                await _evaluationService.GetAllEvaluationsByUserId(userGuid));
            return data;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationResource>> GetEvaluationById(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationById(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            var evaluationResource = _mapper.Map<Evaluation, EvaluationResource>(evaluation);
            return Ok(evaluationResource);
        }
        [HttpPost("create")]
        public async Task<ActionResult<EvaluationResource>> CreateEvaluation([FromBody] EvaluationResource model)
        {
            var token = Request.Headers["Authorization"].ToString();
            var userToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = userToken.Claims.ToArray()[0].Value.ToString();
            var userGuid = new Guid(userId);
            var evaluation = _mapper.Map<EvaluationResource, Evaluation>(model);
            var user = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == userGuid);
            evaluation.CreatedBy = user;
            evaluation.CreatedById = user.Id;
            evaluation.Status = 1;
            var result = await _evaluationService.CreateEvaluation(evaluation);
            if(result != null)
            {
                var professorEvaluation = new ProfessorEvaluationListResource();
                professorEvaluation.User = user;
                professorEvaluation.UserId = user.Id;
                professorEvaluation.Evaluation = evaluation;
                professorEvaluation.EvaluationId = evaluation.Id;
                professorEvaluation.Status = 1;
                var resutl2 = await _professorProfessorEvaluationListService.CreateProfessorEvaluationList(
                    _mapper.Map<ProfessorEvaluationListResource, ProfessorEvaluationList>(professorEvaluation));
                if(resutl2 != null)
                {
                    return Ok(evaluation);
                }
                else { return BadRequest(); }
            }
            else { return BadRequest(); }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvaluation(int id)
        {
            var professorEvaluationListItem = await _professorProfessorEvaluationListService.GetProfessorEvaluationListByEvaluationId(id);
            await _professorProfessorEvaluationListService.DeleteProfessorEvaluationList(professorEvaluationListItem);
            var evaluation = await _evaluationService.GetEvaluationById(id);
            await _evaluationService.DeleteEvaluation(evaluation);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateEvaluation([FromBody] EvaluationResource model)
        {
            var evaluationToUpdate = await _evaluationService.GetEvaluationById(model.Id);
            if (evaluationToUpdate == null) { return NotFound(); }
            var newEvaluation = _mapper.Map<EvaluationResource, Evaluation>(model);
            await _evaluationService.UpdateEvaluation(evaluationToUpdate, newEvaluation);
            return Ok(evaluationToUpdate);
        }
    }
}
