using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        Task Create(QuestionDTO userTest);
        Task Delete(int id);
        Task Update(QuestionDTO userTest);
        Task<IEnumerable<QuestionDTO>> GetAll();
        Task<QuestionDTO> GetById(int id);
        Task<int> CountCorrectAnswers(int id);
    }
}
