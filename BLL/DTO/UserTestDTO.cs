using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enteties;

namespace BLL.DTO
{
    public class UserTestDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public TestDTO Test { get; set; }

        [Required]
        public int Score { get; set; }

        public double TimePassed { get; set; }
        public DateTime PassageDate { get; set; }

        public UserTestDTO(UserTest userTest)
        {
            Id = userTest.Id;
            User = new UserDTO(userTest.User);
            Test = new TestDTO(userTest.Test);
            Score = userTest.Score;
            TimePassed = userTest.TimePassed.TotalSeconds;
            PassageDate = userTest.PassageDate;
        }

        public UserTestDTO()
        {
            User = new UserDTO();
            Test = new TestDTO();
        }

        public UserTest GetEntityElement()
        {
            return new UserTest
            {
                Id = this.Id,
                PassageDate = this.PassageDate,
                TimePassed = TimeSpan.FromSeconds(this.TimePassed),
                Score = this.Score,
                TestId = this.Test.Id,
                UserId = this.User.Id
            };
        }
    }
}
