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
        [Required]
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int TestId { get; set; }
        public virtual Test Test { get; set; } 

        [Required]
        public int Score { get; set; }

        public TimeSpan TimePassed { get; set; }
        public DateTime PassageDate { get; set; }
    }
}
