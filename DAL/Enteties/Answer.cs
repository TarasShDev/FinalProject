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

        public ICollection<Question> CorrectQuestions { get; set; }
        public ICollection<Question> OtherQuestions { get; set; }

        public Answer()
        {
            CorrectQuestions = new List<Question>();
            OtherQuestions = new List<Question>();
        }
    }
}
