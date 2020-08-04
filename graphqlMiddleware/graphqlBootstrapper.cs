using Autofac;

namespace graphqlMiddleware
{
    public static class GraphqlBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
           // containerBuilder.RegisterType<GraphSchema>().SingleInstance();
        }
    }
}
