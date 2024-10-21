namespace TinyTableRoller.Helpers
{

    public static class ServiceHelper
    {
        public static IServiceProvider? Services { get; private set; }

        public static void Initialize(IServiceProvider serviceProvider) =>
            Services = serviceProvider;

        public static T GetService<T>()
        {
            if (Services is null)
                throw new ApplicationException("Services not initialized");

            var service = Services.GetService<T>();

            if(service is null)
                throw new ApplicationException(nameof(service));

            return service;
        }
    }
}
