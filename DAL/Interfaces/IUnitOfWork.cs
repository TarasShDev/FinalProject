using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enteties;
using DAL.Identity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Answer> Answers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Test> Tests { get; }
        IRepository<UserTest> UserTests { get; }
        TestUserManager UserManager { get; }
        TestRoleManager RoleManager { get; }
        void Save();
    }
}
