using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserTestService:IDisposable
    {
        Task Create(UserTestDTO userTest);
        Task Delete(int id);
        Task Update(UserTestDTO userTest);
        Task<IEnumerable<UserTestDTO>> GetAll();
        Task<UserTestDTO> GetById(int id);
        IEnumerable<UserTestDTO> Find(DateTime? dateFrom, int? userId, int? testId, int? scoreMin, int? scoreMax, TimeSpan? passedTime);
    }
}
