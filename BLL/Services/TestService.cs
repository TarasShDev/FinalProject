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
                throw new ArgumentNullException("Сталася помилка");
            if (test.Description.Length < Constraints.Test.DescriptionMinLength || test.Description.Length > Constraints.Test.DescriptionMaxLength)
                throw new FormatException($"Опис має бути в межах {Constraints.Test.DescriptionMinLength} - {Constraints.Test.DescriptionMaxLength} символів.");
            if (test.Name.Length < Constraints.Test.NameMinLength || test.Name.Length > Constraints.Test.NameMaxLength)
                throw new FormatException($"Назва тесту має бути в межах {Constraints.Test.NameMinLength} - {Constraints.Test.NameMaxLength} символів.");
            if (test.PassageTime.TotalMinutes < Constraints.Test.MinMinutes || test.PassageTime.TotalMinutes > Constraints.Test.MaxMinutes)
                throw new ArgumentOutOfRangeException($"Тривалість тесту має бути в межах {Constraints.Test.MinMinutes} - {Constraints.Test.MaxMinutes} хвилин");
            _unitOfWork.Tests.Create(test.GetEntityElement());
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Tests.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TestDTO>> FindByNameAsync(string name)
        {
            var result = await _unitOfWork.Tests.Find(x => x.Name.ToLower().Contains(name.ToLower()));
            if (result == null || result.Count()==0)
                return null;
            return result.Select(x => new TestDTO(x) { IsOpened=isOpened(x)});
        }

        public async Task<IEnumerable<TestDTO>> FindOpenedByNameAsync(string name)
        {
            var result = await _unitOfWork.Tests.Find(t => t.Name.ToLower().Contains(name.ToLower()) && isOpened(t));
            if (result == null || result.Count()==0)
                return null;
            return result.Select(x => new TestDTO(x) { IsOpened=true});
        }

        public async Task<IEnumerable<TestDTO>> GetAllAsync()
        {
            var result = await _unitOfWork.Tests.GetAll();
            if (result == null || result.Count() == 0)
                return null;
            return result.Select(t => new TestDTO(t) { IsOpened=isOpened(t)});
        }

        public async Task<IEnumerable<TestDTO>> GetAllOpenedAsync()
        {
            var result = await _unitOfWork.Tests.Find(t => isOpened(t));
            if (result == null || result.Count() == 0)
                return null;
            return result.Select(x => new TestDTO(x) { IsOpened=true});
        }

        public async Task<TestDTO> GetByIdAsync(int id)
        {
            Test test = await _unitOfWork.Tests.Get(id);
            if (test == null)
                return null;
            return new TestDTO(test) { IsOpened = isOpened(test) };
        }

        public async Task<TestDTO> GetByIdDetailedForUserAsync(int id)
        {
            Test test = await _unitOfWork.Tests.Get(id);
            if (test == null)
                return null;
            return new TestDTO(test)
            {
                Questions = test.Questions.Select(q => new QuestionDTO(q)
                {
                    Answers =q.Answers.Select(a => new AnswerDTO(a) { IsCorrect=false, Value=q.Answers.Count==1?"":a.Value}).ToList()
                }).ToList(),
                IsOpened=isOpened(test)
            };
        }

        public async Task<TestDTO> GetByIdDetailedForAdminAsync(int id)
        {
            Test test = await _unitOfWork.Tests.Get(id);
            if (test == null)
                return null;
            return new TestDTO(test)
            {
                Questions = test.Questions.Select(q => new QuestionDTO(q)
                {
                    Answers = q.Answers.Select(a => new AnswerDTO(a) { IsCorrect = a.IsCorrect }).ToList()
                }).ToList(),
                IsOpened=isOpened(test)
            };
        }

        public async Task UpdateAsync(TestDTO test)
        {
            if (test == null)
                throw new ArgumentNullException("Сталася помилка");
            if (test.Description.Length < Constraints.Test.DescriptionMinLength || test.Description.Length > Constraints.Test.DescriptionMaxLength)
                throw new FormatException($"Опис має бути в межах {Constraints.Test.DescriptionMinLength} - {Constraints.Test.DescriptionMaxLength} символів.");
            if (test.Name.Length < Constraints.Test.NameMinLength || test.Name.Length > Constraints.Test.NameMaxLength)
                throw new FormatException($"Назва тесту має бути в межах {Constraints.Test.NameMinLength} - {Constraints.Test.NameMaxLength} символів.");
            if (test.PassageTime.TotalMinutes < Constraints.Test.MinMinutes || test.PassageTime.TotalMinutes > Constraints.Test.MaxMinutes)
                throw new ArgumentOutOfRangeException($"Тривалість тесту має бути в межах {Constraints.Test.MinMinutes} - {Constraints.Test.MaxMinutes} хвилин");
            Test result = await _unitOfWork.Tests.Get(test.Id);
            if (result == null)
                throw new ArgumentNullException("Сталася помилка");
            result.Description = test.Description;
            result.Name = test.Name;
            result.PassageTime = test.PassageTime;
            _unitOfWork.Tests.Update(result);
            await _unitOfWork.SaveAsync();
        }

        private bool isOpened(Test test)
        {
            return test.Questions.Any() && test.Questions.All(q => q.Answers.Any(a => a.IsCorrect));
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
