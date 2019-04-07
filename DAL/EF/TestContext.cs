using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Enteties;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DAL.EF
{
    public class TestContext:DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<User> Users { get; set; }

        public TestContext(string connectionString) : base(connectionString)
        {

        }


        static TestContext()
        {
            Database.SetInitializer<TestContext>(new TestDbInitializer());
        }

        public class TestDbInitializer: DropCreateDatabaseIfModelChanges<TestContext>
        {
            protected override void Seed(TestContext context)
            {
                Test test1 = new Test { Description = "Test2 is good", Name = "Test2" };
                context.Tests.Add(test1);
                context.SaveChanges();
            }
        }
    }

   
}
