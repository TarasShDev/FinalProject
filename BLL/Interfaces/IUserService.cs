using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using System.Security.Claims;
using DAL.Interfaces;

namespace BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task Create(UserDTO user);
        Task Delete(int id);
        Task Update(UserDTO user);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
    }
}
