using EQUIZY.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStateProvinceRepository StatesProvinces { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        ITypeAddressRepository TypesAddress { get; }
        IUserAddressListRepository UserAddressList { get; }
        IAddressRepository Addresses { get; }
        ITopicEvaluationRepository TopicsEvaluation { get;  }
        ITopicQuestionRepository TopicsQuestion { get; }
        ICategoryEvaluationRepository CategoriesEvaluation { get; }
        ICategoryQuestionRepository CategoriesQuestion { get; }
        ITypeEvaluationRepository TypesEvaluation { get; }
        ITypeQuestionRepository TypesQuestion { get; }
        IEvaluationRepository Evaluations { get; }
        IProfessorEvaluationListRepository ProfessorEvaluationList { get; }
        Task<int> CommitAsync();
    }
}
