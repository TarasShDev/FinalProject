using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserTestDTO
    {
        public string UserId { get; set; }

        public int TestId { get; set; }

        public int Score { get; set; }

        public TimeSpan TimePassed { get; set; }
        public DateTime PassageDate { get; set; }
    }
}
