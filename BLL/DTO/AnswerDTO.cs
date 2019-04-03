using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enteties;

namespace BLL.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }

        public static AnswerDTO GetDTOElement(Answer answer)
        {
            return new AnswerDTO
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                Value = answer.Value
            };
        }

        public static Answer GetEntityElement(AnswerDTO answer)
        {
            return new Answer
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                Value = answer.Value,
                IsCorrect=answer.IsCorrect
            };
        }
    }
}
