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
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(UserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException();
            bool isCreated = (await _unitOfWork.Users.Find(x => x.Name == user.Name)).Any();
            if (isCreated)
                throw new ArgumentException("Користувач з даним іменем вже існує");
            if (user.Name.Length < Constraints.User.NameMinLength || user.Name.Length > Constraints.User.NameMaxLength)
                throw new FormatException();
            _unitOfWork.Users.Create(new User { Name = user.Name });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Users.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> FindAsync(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            return (await _unitOfWork.Users.Find(x => x.Name.Contains(name))).Select(t => new UserDTO(t));
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return (await _unitOfWork.Users.GetAll()).Select(u => new UserDTO(u));
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return new UserDTO(await _unitOfWork.Users.Get(id));
        }

        public async Task UpdateAsync(UserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException();
            var result = await _unitOfWork.Users.Find(x => x.Name == user.Name);
            bool isCreated = result.Any() && result.FirstOrDefault().Id != user.Id;
            if (isCreated)
                throw new ArgumentException("Користувач з даним іменем вже існує");
            if (user.Name.Length < Constraints.User.NameMinLength || user.Name.Length > Constraints.User.NameMaxLength)
                throw new FormatException();
            User newUser = await _unitOfWork.Users.Get(user.Id);
            newUser.Name = user.Name;
            _unitOfWork.Users.Update(newUser);
            await _unitOfWork.SaveAsync();
        }
    }
}
