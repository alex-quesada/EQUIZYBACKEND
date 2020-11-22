using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ITypeQuestionService
    {
        Task<IEnumerable<TypeQuestion>> GetAllTypeQuestion();
        Task<TypeQuestion> GetTypeQuestionById(int id);
        Task<TypeQuestion> CreateTypeQuestion(TypeQuestion newTypeQuestion);
        Task UpdateTypeQuestion(TypeQuestion typeQuestionToUpdate, TypeQuestion typeQuestion);
        Task DeleteTypeQuestion(TypeQuestion typeQuestion);
    }
}
