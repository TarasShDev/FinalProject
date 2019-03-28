using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Enteties
{
    public class Test
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Required]
        public TimeSpan PassageTime { get; set; }

        [Required]
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
