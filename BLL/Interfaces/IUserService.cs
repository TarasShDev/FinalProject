using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using System.Security.Claims;
using DAL.Identity;

namespace BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task Create(UserDTO user);
        //Task<ClaimsIdentity> Authenticate(UserDTO user);
        Task Delete(string id);
        Task<IEnumerable<UserDTO>> GetAll();
        TestUserManager GetUserManager();
    }
}
