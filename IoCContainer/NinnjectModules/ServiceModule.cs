using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace IoCContainer.NinnjectModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<ITestService>().To<TestService>();
            Bind<IUserTestService>().To<UserTestService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
