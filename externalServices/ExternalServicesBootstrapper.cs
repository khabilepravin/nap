using Autofac;

namespace externalServices
{
    public static class ExternalServicesBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TextToSpeech>().As<ITextToSpeech>().SingleInstance();
        }

    }
}
