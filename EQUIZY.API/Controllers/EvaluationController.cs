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
        private readonly IQuizQuestionService _quizQuestionService;
        private readonly IQuestionListService _questionListService;
        private readonly IAnswerService _answerService;
        private readonly IAnswerListService _answerListService;
        private readonly ICategoryQuestionService _categoryQuestionService;
        private readonly ITopicQuestionService _topicQuestionService;
        private readonly ITypeQuestionService _typeQuestionService;
        private readonly IProfessorProfessorEvaluationListService _professorProfessorEvaluationListService;

        public EvaluationController(IMapper mapper, 
            ITopicEvaluationService topicEvaluationService, 
            ITypeEvaluationService typeEvaluationService, 
            ICategoryEvaluationService categoryEvaluationService,
            UserManager<AppUser> userManager,
            IEvaluationService evaluationService,
            IProfessorProfessorEvaluationListService professorProfessorEvaluationListService,
            IQuizQuestionService quizQuestionService,
            IQuestionListService questionListService,
            IAnswerListService answerListService,
            ICategoryQuestionService categoryQuestionService,
            ITopicQuestionService topicQuestionService,
            ITypeQuestionService typeQuestionService,
            IAnswerService answerService)
        {
            _mapper = mapper;
            _topicEvaluationService = topicEvaluationService;
            _typeEvaluationService = typeEvaluationService;
            _categoryEvaluationService = categoryEvaluationService;
            _userManager = userManager;
            _evaluationService = evaluationService;
            _quizQuestionService = quizQuestionService;
            _questionListService = questionListService;
            _answerService = answerService;
            _answerListService = answerListService;
            this._categoryQuestionService = categoryQuestionService;
            this._topicQuestionService = topicQuestionService;
            this._typeQuestionService = typeQuestionService;
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
            var evaluationsData = new EvaluationWithInfoResource();
            evaluationsData.Topics = _mapper.Map<
                IEnumerable<TopicQuestion>, List<TopicQuestionResource>>(
                await _topicQuestionService.GetAllTopicQuestion());
            evaluationsData.Categories = _mapper.Map<
                IEnumerable<CategoryQuestion>, List<CategoryQuestionResource>>(
                await _categoryQuestionService.GetAllCategoryQuesation());
            evaluationsData.Types = _mapper.Map<
                IEnumerable<TypeQuestion>, List<TypeQuestionResource>>(
                await _typeQuestionService.GetAllTypeQuestion());
            evaluationsData.Evaluation = evaluationResource;
            return Ok(evaluationsData);
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
        [HttpPost("question/create")]
        public async Task<ActionResult<QuestionResource>> CreateQuestion([FromBody] CreateQuestionResource model)
        {
            var token = Request.Headers["Authorization"].ToString();
            var userToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = userToken.Claims.ToArray()[0].Value.ToString();
            var userGuid = new Guid(userId);
            
            foreach (var quest in model.Questions)
            {
                if (quest.Id > 0) {
                    var question = _mapper.Map<QuestionResource, QuizQuestion>(quest);
                    var questionToUpdate = await _quizQuestionService.GetQuestionById(quest.Id);
                    await _quizQuestionService.UpdateQuestion(questionToUpdate, question);

                }
                else
                {
                    var questionToAdd = _mapper.Map<QuestionResource, QuizQuestion>(quest);
                    questionToAdd.CreatedById = userGuid;
                    questionToAdd.Status = 1;
                    foreach (var ans in questionToAdd.Answers)
                    {
                        ans.Status = 1;
                    }
                    var questionResult = await _quizQuestionService.CreateQuestion(questionToAdd);
                    if (questionResult == null)
                        return BadRequest();
                }
            }
            return Ok();
        }
        [HttpGet("/question/{id}")]
        public async Task<ActionResult<EvaluationResource>> GetQuestionById(int id)
        {
            var question = await _quizQuestionService.GetQuestionById(id);
            if (question == null)
            {
                return NotFound();
            }
            var questionResource = _mapper.Map<QuizQuestion, QuestionResource>(question);
            return Ok(questionResource);
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
