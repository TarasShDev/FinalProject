using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAnswerService
    {
        Task Create(AnswerDTO userTest);
        Task Delete(int id);
        Task Update(AnswerDTO userTest);
        Task<IEnumerable<AnswerDTO>> GetAll();
        Task<AnswerDTO> GetById(int id);
    }
}
