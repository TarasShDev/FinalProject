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
        Task AddAsync(UserDTO user);
        Task DeleteAsync(int id);
        Task UpdateAsync(UserDTO user);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<IEnumerable<UserDTO>> FindAsync(string name);
    }
}
