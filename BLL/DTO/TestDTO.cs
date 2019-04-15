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
    public class TestDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Constraints.Test.DescriptionMaxLength), MinLength(Constraints.Test.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(Constraints.Test.NameMaxLength), MinLength(Constraints.Test.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(Constraints.Test.MinMinutes, Constraints.Test.MaxMinutes)]
        public double PassageTime { get; set; }

        public bool IsOpened { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }

        public TestDTO (Test test)
        {
            Id = test.Id;
            Description = test.Description;
            Name = test.Name;
            PassageTime = test.PassageTime;
        }

        public TestDTO() { }

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
