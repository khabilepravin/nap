using Autofac;
using dataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess
{
    public static class DataBootstrapper
    {
        public static void Boostrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TestRepository>().As<ITestRepository>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            containerBuilder.RegisterType<UserTestRepository>().As<IUserTestRepository>();
        }
    }
}
