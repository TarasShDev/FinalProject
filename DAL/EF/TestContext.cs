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
    public class TestContext: IdentityDbContext<User>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        public TestContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasMany<Answer>(q => q.CorrectAnswers).WithMany(a => a.CorrectQuestions);
            modelBuilder.Entity<Question>().HasMany<Answer>(q => q.OtherAnswers).WithMany(a => a.OtherQuestions);
            modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => r.RoleId);
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
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
