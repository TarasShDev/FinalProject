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
        public string Id { get; set; }
        public string Name { get; set; }
        

        public static UserDTO GetMappedElement(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
    }
}
