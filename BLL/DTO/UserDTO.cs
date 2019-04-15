using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Constraints;
using DAL.Enteties;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Constraints.User.NameMaxLength), MinLength(Constraints.User.NameMinLength)]
        public string Name { get; set; }
        
        public UserDTO (User user)
        {
            Id = user.Id;
            Name = user.Name;
        }
        public UserDTO()
        { }

        public User GetEntityElement()
        {
            return new User
            {
                Name = Name
            };
        }
    }
}
