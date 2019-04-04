﻿using System;
using System.Collections.Generic;
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

        public int Score { get; set; }

        public TimeSpan TimePassed { get; set; }
        public DateTime PassageDate { get; set; }

        public UserTestDTO(UserTest userTest)
        {
            Id = userTest.Id;
            User = new UserDTO(userTest.User);
            Test = new TestDTO(userTest.Test);
            Score = userTest.Score;
            TimePassed = userTest.TimePassed;
            PassageDate = userTest.PassageDate;
        }

    }
}
