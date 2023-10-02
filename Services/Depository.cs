using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NetCoreWebApp_Logging.Services
{
    /// <summary>
    /// Logging in ASP.NET Core is available through the built-in Dependency Inversion (DI). 
    /// If you inspect the ConfigureLogging method, 
    /// it calls AddLogging, which registers a generic ILogger in the DI container as follows:
    /// </summary>
    public class Depository : IDepository
    {
        public IServiceCollection AddLogging( IServiceCollection services, Action<ILoggingBuilder> configure)
        {
            // code omitted for brevity
            services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory, LoggerFactory>());
            services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
            return services;
        }      
      
    }
}
