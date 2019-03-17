using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace DAL.Enteties
{
    public class User: IdentityUser
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public virtual ICollection<UserTest> UserTests { get; set; }

        public User()
        {
            UserTests = new List<UserTest>();
        }
    }
}
