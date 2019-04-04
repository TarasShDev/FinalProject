using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Enteties;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Constraints;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TestDTO test)
        {
            if (test == null)
                throw new ArgumentNullException();
            if (test.Description.Length < Constraints.Test.DescriptionMinLength || test.Description.Length > Constraints.Test.DescriptionMaxLength)
                throw new FormatException();
            if (test.Name.Length < Constraints.Test.NameMinLength || test.Name.Length > Constraints.Test.NameMaxLength)
                throw new FormatException();
            if (test.PassageTime.TotalMinutes < Constraints.Test.MinMinutes || test.PassageTime.TotalMinutes > Constraints.Test.MaxMinutes)
                throw new ArgumentOutOfRangeException();
            _unitOfWork.Tests.Create(TestDTO.GetEntityElement(test));
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Tests.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TestDTO>> FindAsync(string name)
        {
            return (await _unitOfWork.Tests.Find(x => x.Name.Contains(name))).Select(x => new TestDTO(x) { IsOpened=isOpened(x)});
        }

        public async Task<IEnumerable<TestDTO>> FindOpenedAsync(string name)
        {
            return (await _unitOfWork.Tests.Find(t => t.Name.Contains(name) && isOpened(t))).Select(x => new TestDTO(x) { IsOpened=true});
        }

        public async Task<IEnumerable<TestDTO>> GetAllAsync()
        {
            return (await _unitOfWork.Tests.GetAll()).Select(t => new TestDTO(t) { IsOpened=isOpened(t)});
        }

        public async Task<IEnumerable<TestDTO>> GetAllOpenedAsync()
        {
            return (await _unitOfWork.Tests.Find(t => isOpened(t))).Select(x => new TestDTO(x) { IsOpened=true});
        }

        public async Task<TestDTO> GetByIdAsync(int id)
        {
            Test test = await _unitOfWork.Tests.Get(id);
            return new TestDTO(test) { IsOpened = isOpened(test) };
        }

        public async Task<TestDTO> GetByIdDetailedAsync(int id)
        {
            Test test = await _unitOfWork.Tests.Get(id);
            return new TestDTO(test)
            {
                Questions = test.Questions.Select(q => new QuestionDTO(q)
                {
                    Answers =q.Answers.Select(a => new AnswerDTO(a) { IsCorrect=false}).ToList()
                }).ToList()
            };
        }

        public async Task UpdateAsync(TestDTO test)
        {
            if (test == null)
                throw new ArgumentNullException();
            if (test.Description.Length < Constraints.Test.DescriptionMinLength || test.Description.Length > Constraints.Test.DescriptionMaxLength)
                throw new FormatException();
            if (test.Name.Length < Constraints.Test.NameMinLength || test.Name.Length > Constraints.Test.NameMaxLength)
                throw new FormatException();
            if (test.PassageTime.TotalMinutes < Constraints.Test.MinMinutes || test.PassageTime.TotalMinutes > Constraints.Test.MaxMinutes)
                throw new ArgumentOutOfRangeException();
            Test result = await _unitOfWork.Tests.Get(test.Id);
            if (result == null)
                throw new ArgumentNullException();
            result.Description = test.Description;
            result.Name = test.Name;
            result.PassageTime = test.PassageTime;
            _unitOfWork.Tests.Update(result);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> IsOpened(int id)
        {
            Test test = await _unitOfWork.Tests.Get(id);
            if (test == null)
                throw new ArgumentNullException();
            return isOpened(test);
        }

        Func<Test, bool> isOpened = x =>
        {
            return x.Questions.Any() && x.Questions.All(q => q.Answers.Any(a => a.IsCorrect));
        };
    }
}
