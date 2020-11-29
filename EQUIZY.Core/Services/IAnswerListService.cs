using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IAnswerListService
    {
        Task<IEnumerable<AnswerList>> GetAllAnswerList();
        Task<AnswerList> GetAnswerListById(int id);
        Task<IEnumerable<AnswerList>> GetAnswerListByQuestionId(int id);
        Task<AnswerList> CreateAnswerList(AnswerList newAnswerList);
        Task UpdateAnswerList(AnswerList answerListToUpdate, AnswerList answerList);
        Task DeleteAnswerList(AnswerList answerList);
    }
}
