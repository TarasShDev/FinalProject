using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Enteties;
using DAL.Interfaces;

namespace DAL.EF
{
    public class EFUnitOfWork: IUnitOfWork
    {
        TestContext db;
        GenericRepository<Question> questionsRepository;
        GenericRepository<Answer> answersRepository;
        GenericRepository<Test> testsRepository;
        GenericRepository<UserTest> userTestsRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new TestContext(connectionString);
            questionsRepository = new GenericRepository<Question>(db);
            answersRepository = new GenericRepository<Answer>(db);
            testsRepository = new GenericRepository<Test>(db);
            userTestsRepository = new GenericRepository<UserTest>(db);
        }

        public IRepository<Answer> Answers
        {
            get
            {
                return answersRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                return questionsRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                return testsRepository;
            }
        }

        public IRepository<UserTest> UserTests
        {
            get
            {
                return userTestsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
