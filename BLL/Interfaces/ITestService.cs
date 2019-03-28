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
        Task Create(TestDTO userTest);
        Task Delete(int id);
        Task Update(TestDTO userTest);
        IEnumerable<TestDTO> GetAll();
        Task<TestDTO> GetById(int id);
        Task<IEnumerable<TestDTO>> Find(string name);
        Task<bool> IsOpened(int id);
    }
}
