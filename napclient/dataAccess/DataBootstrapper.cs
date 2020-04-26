using Autofac;
using dataAccess.Repositories;
using dataModel.Repositories;

namespace dataAccess
{
    public static class DataBootstrapper
    {
        public static void Boostrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DbContextFactory>().As<IDbContextFactory>().SingleInstance();
            containerBuilder.RegisterType<TestRepository>().As<ITestRepository>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            containerBuilder.RegisterType<UserTestRepository>().As<IUserTestRepository>();
            containerBuilder.RegisterType<UserTestRecordRepository>().As<IUserTestRecordRepository>();
            containerBuilder.RegisterType<AnswerRepository>().As<IAnswerRepository>();
            containerBuilder.RegisterType<ExplanationRepository>().As<IExplanationRepository>();
        }
    }
}
