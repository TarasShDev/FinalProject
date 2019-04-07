using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Other;

namespace BLL.Interfaces
{
    public interface IUserTestService:IDisposable
    {
        Task AddAsync(UserTestDTO userTest, int userId);
        Task DeleteAsync(int id);
        Task UpdateAsync(UserTestDTO userTest);

        Task<IEnumerable<UserTestDTO>> GetAllAsync();
        Task<UserTestDTO> GetByIdAsync(int id);
        Task<IEnumerable<UserTestDTO>> FindAsync(SearchParameters parameter);
    }
}
