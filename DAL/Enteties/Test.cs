using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DAL.Constraints;

namespace DAL.Enteties
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Constraints.Constraints.Test.DescriptionMaxLength), MinLength(Constraints.Constraints.Test.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Range(Constraints.Constraints.Test.MinMinutes, Constraints.Constraints.Test.MaxMinutes)]
        public double PassageTime { get; set; }

        [Required]
        [MaxLength(Constraints.Constraints.Test.NameMaxLength), MinLength(Constraints.Constraints.Test.NameMinLength)]
        public string Name { get; set; }

        public virtual ICollection<UserTest> UserTests { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Test()
        {
            UserTests = new List<UserTest>();
            Questions = new List<Question>();
        }
    }
}
