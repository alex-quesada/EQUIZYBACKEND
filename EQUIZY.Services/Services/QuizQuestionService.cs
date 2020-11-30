using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerService _answerService;

        public QuizQuestionService(IUnitOfWork unitOfWork, IAnswerService answerService)
        {
            this._unitOfWork = unitOfWork;
            this._answerService = answerService;
        }

        public async Task<QuizQuestion> CreateQuestion(QuizQuestion question)
        {
            await _unitOfWork.QuizQuestions
                .AddAsync(question);
            await _unitOfWork.CommitAsync();
            return question;
        }

        public async Task DeleteQuestion(QuizQuestion question)
        {
            var questionToDelete = await _unitOfWork.QuizQuestions.SingleOrDefaultAsync(m => m.Id == question.Id);
            questionToDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuestions()
        {
            return await _unitOfWork.QuizQuestions.GetAllAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuestionsByEvaluationId(int id)
        {
            return await _unitOfWork.QuizQuestions.GetAllQuestionByEvaluationId(id);
        }

        public async Task<QuizQuestion> GetQuestionById(int id)
        {
            return await _unitOfWork.QuizQuestions.GetQuestionByIdAsync(id);
        }

        public async Task UpdateQuestion(QuizQuestion questionToUpdate, QuizQuestion question)
        {
            questionToUpdate.Question = question.Question;
            questionToUpdate.Points = question.Points;
            questionToUpdate.TimeToAnswer = question.TimeToAnswer;
            questionToUpdate.TopicQuestionId = question.TopicQuestionId;
            questionToUpdate.CategoryQuestionId = question.CategoryQuestionId;
            questionToUpdate.TypeQuestionId = question.TypeQuestionId;
            questionToUpdate.Answers = question.Answers;
            //var oldAnswers = await _answerService.GetAllAnswersByEvaluationId(question.Id);
            foreach (var ans in questionToUpdate.Answers)
            {
                if (ans.Id > 0)
                {
                    var answerToUpdate = await _answerService.GetAnswerById(ans.Id);
                    var answer = new Answer();
                    answer.AnswerContent = ans.AnswerContent;
                    answer.Correct = ans.Correct;
                    await _answerService.UpdateAnswer(answerToUpdate, answer);
                }
                else
                {
                    var answer = new Answer();
                    answer.AnswerContent = ans.AnswerContent;
                    answer.Correct = ans.Correct;
                    await _answerService.CreateAnswer(answer);
                }
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
