using EQUIZY.Core;
using EQUIZY.Core.Repositories;
using EQUIZY.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyEquizyDbContext _context;
        private IStateProvinceRepository _stateProvinceRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private ITypeAddressRepository _typeAddressRepository;
        private IAddressRepository _addressRepository;
        private IUserAddressListRepository _userAddressListRepository;
        private ITopicEvaluationRepository _topicEvaluationRepository;
        private ITopicQuestionRepository _topicQuestionRepository;
        private ICategoryEvaluationRepository _categoryEvaluationRepository;
        private ICategoryQuestionRepository _categoryQuestionRepository;
        private ITypeEvaluationRepository _typesEvaluationRepository;
        private ITypeQuestionRepository _typesQuestionRepository;
        private IProfessorEvaluationListRepository _professorEvaluationListRepository;
        private IEvaluationRepository _evaluationRepository;
        private IAnswerRepository _answerRepository;
        private IAnswerListRepository _answerListRepository;
        private IQuizQuestionRepository _quizQuestionRepository;
        private IQuestionListRepository _questionListRepository;

        public UnitOfWork(MyEquizyDbContext context)
        {
            this._context = context;
        }
        public IStateProvinceRepository StatesProvinces => _stateProvinceRepository = _stateProvinceRepository ?? new StateProvinceRepository(_context);
        public ICountryRepository Countries => _countryRepository = _countryRepository ?? new CountryRepository(_context);
        public ICityRepository Cities => _cityRepository = _cityRepository ?? new CityRepository(_context);
        public ITypeAddressRepository TypesAddress => _typeAddressRepository = _typeAddressRepository ?? new TypeAddressRepository(_context);
        public IAddressRepository Addresses => _addressRepository = _addressRepository ?? new AddressRepository(_context);
        public IUserAddressListRepository UserAddressList => _userAddressListRepository = _userAddressListRepository ?? new UserAddressRepository(_context);
        public ITopicEvaluationRepository TopicsEvaluation => _topicEvaluationRepository = _topicEvaluationRepository ?? new TopicEvaluationRepository(_context);
        public ITopicQuestionRepository TopicsQuestion => _topicQuestionRepository = _topicQuestionRepository ?? new TopicQuestionRepository(_context);
        public ICategoryEvaluationRepository CategoriesEvaluation => _categoryEvaluationRepository = _categoryEvaluationRepository ?? new CategoryEvaluationRepository(_context);
        public ICategoryQuestionRepository CategoriesQuestion => _categoryQuestionRepository = _categoryQuestionRepository ?? new CategoryQuestionRepository(_context);
        public ITypeEvaluationRepository TypesEvaluation => _typesEvaluationRepository = _typesEvaluationRepository ?? new TypeEvaluationRepository(_context);
        public ITypeQuestionRepository TypesQuestion => _typesQuestionRepository = _typesQuestionRepository ?? new TypeQuestionRepository(_context);
        public IEvaluationRepository Evaluations => _evaluationRepository = _evaluationRepository ?? new EvaluationRepository(_context);
        public IProfessorEvaluationListRepository ProfessorEvaluationList => _professorEvaluationListRepository = _professorEvaluationListRepository ?? new ProfessorEvaluationListRepository(_context);
        public IAnswerRepository Answers => _answerRepository = _answerRepository ?? new AnswerRepository(_context);
        public IAnswerListRepository AnswerList => _answerListRepository = _answerListRepository ?? new AnswerListRepository(_context);
        public IQuizQuestionRepository QuizQuestions => _quizQuestionRepository = _quizQuestionRepository ?? new QuizQuestionRepository(_context);
        public IQuestionListRepository QuestionList => _questionListRepository = _questionListRepository ?? new QuestionListRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
