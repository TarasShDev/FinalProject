using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        Task AddAsync(TestDTO test);
        Task DeleteAsync(int id);
        Task UpdateAsync(TestDTO test);
        Task<IEnumerable<TestDTO>> GetAllOpenedAsync();
        Task<IEnumerable<TestDTO>> GetAllAsync();
        Task<TestDTO> GetByIdAsync(int id);
        Task<TestDTO> GetByIdDetailedAsync(int id);
        Task<IEnumerable<TestDTO>> FindAsync(string name);
        Task<IEnumerable<TestDTO>> FindOpenedAsync(string name);
        Task<bool> IsOpened(int id);
    }
}
