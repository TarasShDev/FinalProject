using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enteties;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Header { get; set; }
        public int Points { get; set; }
        public ICollection<AnswerDTO> Answers { get; set; }
        
        public static QuestionDTO GetDTOElement(Question question)
        {
            return new QuestionDTO {
                Id = question.Id,
                Header = question.Header,
                Points = question.Points,
                TestId = question.TestId
            };
        }

        public static Question GetEntityElement(QuestionDTO question)
        {
            return new Question
            {
                Id = question.Id,
                TestId = question.TestId,
                Header = question.Header,
                Points = question.Points
            };
        }
    }
}
