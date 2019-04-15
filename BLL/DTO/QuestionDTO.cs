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
    public class QuestionDTO
    {
        public int Id { get; set; }

        public int TestId { get; set; }

        [Required]
        [MaxLength(Constraints.Question.HeaderMaxLength), MinLength(Constraints.Question.HeaderMinLength)]
        public string Header { get; set; }

        [Required]
        [Range(Constraints.Question.MinPointsValue, Constraints.Question.MaxPointsValue)]
        public int Points { get; set; }

        public ICollection<AnswerDTO> Answers { get; set; }
        
        public QuestionDTO (Question question)
        {
            Id = question.Id;
            Header = question.Header;
            Points = question.Points;
            TestId = question.TestId;
        }

        public Question GetEntityElement()
        {
            return new Question
            {
                TestId = TestId,
                Header = Header,
                Points = Points
            };
        }

        public QuestionDTO()
        { }
    }
}
