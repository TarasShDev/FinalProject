using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Enteties
{
    public class UserTest
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int TestId { get; set; }
        public virtual Test Test { get; set; } 

        [Required]
        public int Score { get; set; }

        public TimeSpan TimePassed { get; set; }
        public DateTime PassageDate { get; set; }
    }
}
