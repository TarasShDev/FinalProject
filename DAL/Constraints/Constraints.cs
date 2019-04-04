using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Constraints
{
    public class Constraints
    {
        public class Question
        {
            public const int HeaderMaxLength = 300;
            public const int HeaderMinLength = 15;
            public const int MinPointsValue = 1;
            public const int MaxPointsValue = Int32.MaxValue;
        }

        public class Test
        {
            public const int DescriptionMaxLength = 800;
            public const int DescriptionMinLength = 1;
            public const int NameMaxLength = 120;
            public const int NameMinLength = 4;
            public const double MinMinutes = 1;
            public const double MaxMinutes = 180;
        }

        public class User
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
        }
    }
}
