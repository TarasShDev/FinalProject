using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Enteties;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Constraints;
using BLL.Other;

namespace BLL.Services
{
    public class UserTestService : IUserTestService
    {
        IUnitOfWork _unitOfWork;

        public UserTestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(UserTestDTO userTest, int userId)
        {
            if (userTest == null)
                throw new ArgumentNullException();
            UserTestDTO result = userTest;
            result.User.Id = userId;
            result.Score = getScore(userTest);
            _unitOfWork.UserTests.Create(result.GetEntityElement());
            await _unitOfWork.SaveAsync();
        }

        private int getScore(UserTestDTO test)
        {
            var userQuestions = test.Test.Questions;
            var originalQuestions = _unitOfWork.Tests.Get(test.Id).Result.Questions;
            double Score = 0;

            foreach(var userQuestion in userQuestions)
            {
                double result = 0;
                var originalQuestion = originalQuestions.First(x => x.Id == userQuestion.Id);
                if (originalQuestion.Answers.Count > 1)
                {
                    var userAnswers = userQuestion.Answers.Where(x => x.IsCorrect).Select(x => x.Id);
                    var correctAnswers = originalQuestion.Answers.Where(x => x.IsCorrect).Select(x => x.Id);

                    result = userAnswers.Intersect(correctAnswers).Count() - Math.Abs(correctAnswers.Count() - userAnswers.Count());
                    result = result < 0 ? 0 : result;
                    //find result in percent
                    result /= correctAnswers.Count();
                    //find total result
                    result *= originalQuestion.Points;
                }
                else
                {
                    if (userQuestion.Answers.First().Value.Trim().ToLower() == originalQuestion.Answers.First().Value)
                        result = originalQuestion.Points;
                }
                Score += result;
            }
            return (int)Score;
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.UserTests.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<UserTestDTO>> FindAsync(SearchParameters parameter)
        {
            if (parameter == null)
                return await GetAllAsync();
            Func<UserTest, bool> predicate = x => (!parameter.dateFrom.HasValue || x.PassageDate >= parameter.dateFrom) &&
                                                    (!parameter.userId.HasValue || x.UserId == parameter.userId) &&
                                                    (!parameter.testId.HasValue || x.TestId == parameter.testId) &&
                                                    (!parameter.maxPassedTime.HasValue || x.TimePassed <= parameter.maxPassedTime) &&
                                                    (!parameter.scoreMin.HasValue || x.Score >= parameter.scoreMin) &&
                                                    (!parameter.scoreMax.HasValue || x.Score <= parameter.scoreMax);
            return (await _unitOfWork.UserTests.Find(predicate)).Select(x => new UserTestDTO(x)).ToList();
        }

        public async Task<IEnumerable<UserTestDTO>> GetAllAsync()
        {
            return (await _unitOfWork.UserTests.GetAll()).Select(x => new UserTestDTO(x)).ToList();
        }

        public async Task<UserTestDTO> GetByIdAsync(int id)
        {
            return new UserTestDTO(await _unitOfWork.UserTests.Get(id));
        }

        public async Task UpdateAsync(UserTestDTO userTest)
        {
            if (userTest == null)
                throw new ArgumentNullException();
            var result = await _unitOfWork.UserTests.Get(userTest.Id);
            if (result == null)
                throw new KeyNotFoundException();   
            result.Score = userTest.Score;
            _unitOfWork.UserTests.Update(result);
            await _unitOfWork.SaveAsync();
        }

    }
}
