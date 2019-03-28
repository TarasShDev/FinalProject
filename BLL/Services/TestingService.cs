using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using DAL.EF;
using DAL.Interfaces;
using DAL.Enteties;

namespace BLL.Services
{
    public class TestingService : IUserService, IUserTestService, ITestService
    {
        private IUnitOfWork _unitOfWork;

        public TestingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Create(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task Create(UserTestDTO userTest)
        {
            throw new NotImplementedException();
        }

        public Task Create(TestDTO userTest)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTestDTO> Find(DateTime? dateFrom, int? userId, int? testId, int? scoreMin, int? scoreMax, TimeSpan? maxPassedTime)
        {
            Func<UserTest, bool> predicate = x => (!dateFrom.HasValue || x.PassageDate >= dateFrom) &&
                                                    (!userId.HasValue || x.UserId == userId) &&
                                                    (!testId.HasValue || x.TestId == testId) &&
                                                    (!maxPassedTime.HasValue || x.TimePassed <= maxPassedTime) &&
                                                    (!scoreMin.HasValue || x.Score >= scoreMin) &&
                                                    (!scoreMax.HasValue || x.Score <= scoreMax);
            
            return _unitOfWork.UserTests.Find(predicate).Select(x=>UserTestDTO.GetMappedElement(x));
        }

        public Task<IEnumerable<TestDTO>> Find(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsOpened(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserTestDTO userTest)
        {
            throw new NotImplementedException();
        }

        public Task Update(TestDTO userTest)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserTestDTO>> IUserTestService.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TestDTO> ITestService.GetAll()
        {
            return _unitOfWork.Tests.GetAll().Select(x => TestDTO.GetMappedElement(x));
        }

        Task<UserTestDTO> IUserTestService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<TestDTO> ITestService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
