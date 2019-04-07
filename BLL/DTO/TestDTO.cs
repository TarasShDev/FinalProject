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
        public bool IsOpened { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }

        public TestDTO (Test test)
        {
            Id = test.Id;
            Description = test.Description;
            Name = test.Name;
            PassageTime = test.PassageTime;
        }

        public Test GetEntityElement()
        {
            return new Test
            {
                Description = Description,
                Name = Name,
                PassageTime = PassageTime
            };
        }

    }
}
