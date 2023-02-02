using Microsoft.Extensions.DependencyInjection;

namespace APIDependencyInjection
{
    public static class DependencyInjection
    {
        public const string PROJECT_NAME = "APIDependencyInjection";

        public static void AddServiceDependency(this IServiceCollection services)
        {
            var type = typeof(DependencyStartup);
            var serviceTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && !x.FullName.StartsWith(PROJECT_NAME))
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var serviceType in serviceTypes)
            {
                var instance = Activator.CreateInstance(serviceType);
                if (instance != null)
                {
                    DependencyStartup startup = (DependencyStartup)instance;
                    startup.AddServices(services);
                }
            }
        }
    }
}