using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Constraints;
using DAL.Enteties;

namespace BLL.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        
        public string Value { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        public AnswerDTO (Answer answer)
        {
            Id = answer.Id;
            QuestionId = answer.QuestionId;
            Value = answer.Value;
        }

        public AnswerDTO() { }

        public Answer GetEntityElement()
        {
            return new Answer
            {
                QuestionId = QuestionId,
                Value = Value.Trim(),
                IsCorrect = IsCorrect
            };
        }
    }
}
