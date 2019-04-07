using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Enteties;
using DAL.Constraints;

namespace BLL.Services
{
    public class AnswerService : IAnswerService
    {
        IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(AnswerDTO answer)
        {
            if (answer == null)
                throw new ArgumentNullException("Сталася помилка");
            if (answer.Value.Length < Constraints.Answer.ValueMinLength || answer.Value.Length > Constraints.Answer.ValueMaxLength)
                throw new FormatException($"Відповідь має бути в межах {Constraints.Answer.ValueMinLength} - {Constraints.Answer.ValueMaxLength} символів.");
            _unitOfWork.Answers.Create(answer.GetEntityElement());
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Answers.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<AnswerDTO> GetByIdAsync(int id)
        {
            Answer answer = await _unitOfWork.Answers.Get(id);
            if (answer == null)
                return null;
            return new AnswerDTO(answer);
        }

        public async Task UpdateAsync(AnswerDTO answer)
        {
            if (answer == null)
                throw new ArgumentNullException("Сталася помилка");
            if(answer.Value.Length<Constraints.Answer.ValueMinLength || answer.Value.Length>Constraints.Answer.ValueMaxLength)
                throw new FormatException($"Відповідь має бути в межах {Constraints.Answer.ValueMinLength} - {Constraints.Answer.ValueMaxLength} символів.");
            Answer ans = await _unitOfWork.Answers.Get(answer.Id);
            if (ans == null)
                throw new ArgumentNullException();
            ans.Id = answer.Id;
            ans.IsCorrect = answer.IsCorrect;
            ans.QuestionId = answer.QuestionId;
            ans.Value = answer.Value;
            _unitOfWork.Answers.Update(ans);
            await _unitOfWork.SaveAsync();
        }
    }
}
