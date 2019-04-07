using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IQuestionService:IDisposable
    {
        Task CreateAsync(QuestionDTO question);
        Task DeleteAsync(int id);
        Task UpdateAsync(QuestionDTO question);
        Task<QuestionDTO> GetByIdAsync(int id);
    }
}
