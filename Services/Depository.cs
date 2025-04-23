using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NetCoreWebApp_Logging.Services
{
   /// <summary>
    /// Logging in ASP.NET Core is configured through Dependency Injection (DI). 
    /// The ConfigureLogging method calls AddLogging, which registers a generic ILogger in the DI container.
    /// This approach follows the Dependency Inversion Principle (DIP), as high-level modules depend on abstractions (ILogger<T>) rather than concrete implementations.
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
