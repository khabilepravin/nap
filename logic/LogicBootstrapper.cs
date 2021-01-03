using Autofac;

namespace logic
{
    public static class LogicBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserTestLogic>().As<IUserTestLogic>().SingleInstance();
            containerBuilder.RegisterType<TestResultLogic>().As<ITestResultLogic>().SingleInstance();
            containerBuilder.RegisterType<QuestionLogic>().As<IQuestionLogic>().SingleInstance();
            containerBuilder.RegisterType<AnswerLogic>().As<IAnswerLogic>().SingleInstance();
            containerBuilder.RegisterType<PracticeTestLogic>().As<IPracticeTestLogic>().SingleInstance();
            containerBuilder.RegisterType<UserLogic>().As<IUserLogic>().SingleInstance();
            containerBuilder.RegisterType<TestLogic>().As<ITestLogic>().SingleInstance();


        }
    }
}
