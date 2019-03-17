using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Enteties
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [Required]
        [MaxLength(370)]
        public string QuestionHeader { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<Answer> CorrectAnswers { get; set; }
        public virtual ICollection<Answer> OtherAnswers { get; set; }

        public Question()
        {
            CorrectAnswers = new List<Answer>();
            OtherAnswers = new List<Answer>();
        }
    }
}
