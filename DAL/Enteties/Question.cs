using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DAL.Constraints;

namespace DAL.Enteties
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [Required]
        [MaxLength(Constraints.Constraints.Question.HeaderMaxLength), MinLength(Constraints.Constraints.Question.HeaderMinLength)]
        public string Header { get; set; }

        [Required]
        [Range(Constraints.Constraints.Question.MinPointsValue, Constraints.Constraints.Question.MaxPointsValue)]
        public int Points { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
