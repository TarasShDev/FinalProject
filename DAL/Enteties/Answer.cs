using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Enteties
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
        
        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        
    }
}
