using Autofac;

namespace logic
{
    public static class LogicBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserTestLogic>().As<IUserTestLogic>().SingleInstance();
        }
    }
}
