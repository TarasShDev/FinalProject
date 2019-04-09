using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enteties;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public UserDTO (User user)
        {
            Id = user.Id;
            Name = user.Name;
        }
        public UserDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User GetEntityElement()
        {
            return new User
            {
                Name = Name
            };
        }
    }
}
