using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enteties;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public TimeSpan PassageTime { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }

        public static TestDTO GetMappedElement(Test test)
        {
            return new TestDTO
            {
                Id = test.Id,
                Description = test.Description,
                Name = test.Name,
                PassageTime = test.PassageTime,
                Questions = new List<QuestionDTO>(test.Questions.Select(x => QuestionDTO.GetMappedElement(x)).ToList())
            };
        }
    }
}
