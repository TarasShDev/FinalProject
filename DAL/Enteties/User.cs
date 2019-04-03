using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace DAL.Enteties
{
    public class User
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(Constraints.Constraints.User.NameMaxLength), MinLength(Constraints.Constraints.User.NameMinLength)]
        public string Name { get; set; }

        public virtual ICollection<UserTest> UserTests { get; set; }

        public User()
        {
            UserTests = new List<UserTest>();
        }
        
    }
}
