using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAnswerService:IDisposable
    {
        Task CreateAsync(AnswerDTO answer);
        Task DeleteAsync(int id);
        Task UpdateAsync(AnswerDTO answer);
        Task<AnswerDTO> GetByIdAsync(int id);
    }
}
