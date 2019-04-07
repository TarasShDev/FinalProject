using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DAL.Constraints;

namespace DAL.Enteties
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Constraints.Constraints.Answer.ValueMinLength), MaxLength(Constraints.Constraints.Answer.ValueMaxLength)]
        public string Value { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
        
        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        
    }
}
