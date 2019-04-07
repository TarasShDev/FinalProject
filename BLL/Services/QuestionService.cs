using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Enteties;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Constraints;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(QuestionDTO question)
        {
            if (question == null)
                throw new ArgumentNullException();
            if (question.Points < Constraints.Question.MaxPointsValue || question.Points > Constraints.Question.MaxPointsValue)
                throw new ArgumentOutOfRangeException();
            if (question.Header.Length < Constraints.Question.HeaderMinLength || question.Header.Length > Constraints.Question.HeaderMaxLength)
                throw new FormatException();
            _unitOfWork.Questions.Create(question.GetEntityElement());
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Questions.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<QuestionDTO> GetByIdAsync(int id)
        {
            Question question = await _unitOfWork.Questions.Get(id);
            if (question == null)
                throw new ArgumentNullException();
            return new QuestionDTO(question);
        }

        public async Task UpdateAsync(QuestionDTO question)
        {
            if (question == null)
                throw new ArgumentNullException();
            if (question.Points < Constraints.Question.MaxPointsValue || question.Points > Constraints.Question.MaxPointsValue)
                throw new ArgumentOutOfRangeException();
            if (question.Header.Length < Constraints.Question.HeaderMinLength || question.Header.Length > Constraints.Question.HeaderMaxLength)
                throw new FormatException();
            Question quest = await _unitOfWork.Questions.Get(question.Id);
            if (quest == null)
                throw new ArgumentNullException();
            quest.Header = question.Header;
            quest.Points = question.Points;
            quest.TestId = question.TestId;
            _unitOfWork.Questions.Update(quest);
            await _unitOfWork.SaveAsync();
        }
    }
}
