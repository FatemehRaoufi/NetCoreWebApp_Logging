Project Overview
This project demonstrates the usage of Logging in an ASP.NET Core application. It integrates Serilog for structured logging, utilizes Dependency Injection (DI), and adheres to the Dependency Inversion Principle (DIP). The application also showcases how to configure logging with different providers like Console, File, and EventLog.
________________________________________
Key Features
•	Logging with Serilog: Use Serilog as the primary logging framework instead of the built-in ILoggerFactory.
•	ASP.NET Core Razor Pages: Demonstrates the use of ILogger to log messages and exceptions within a Razor Pages application.
•	Dependency Injection: Implements DI to configure services like logging and handle dependency inversion properly.
•	Multiple Log Providers: Configures different log providers such as Console, File, and EventLog.
________________________________________
Getting Started
1. Install Required Packages
Before you start, install the necessary NuGet packages:
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package NetEscapades.Extensions.Logging.RollingFile
2. Set Up Logging in Program.cs
In Program.cs, configure logging to use Serilog, the console logger, and file logging:
using NetCoreWebApp_Logging.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();

// Configure event log settings
builder.Logging.AddEventLog(eventLogSettings =>
{
    eventLogSettings.SourceName = "LogglyGuide";
});

// Configure logging providers
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders(); // Clear existing providers
    logging.AddConsole(); // Add Console logger
    logging.AddFile();    // Add File logger (requires NetEscapades.Extensions.Logging.RollingFile package)
});

// Use Serilog for structured logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.WriteTo.Console());
    
// Add custom services (e.g., IDepository)
builder.Services.AddScoped<IDepository, Depository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
3. Define IDepository Interface
Create an interface to manage logging functionality:
namespace NetCoreWebApp_Logging.Services
{
    public interface IDepository
    {
        IServiceCollection AddLogging(IServiceCollection services, Action<ILoggingBuilder> configure);
    }
}
4. Implement Logging in Depository Class
Implement the AddLogging method to register logging services:
namespace NetCoreWebApp_Logging.Services
{
    public class Depository : IDepository
    {
        public IServiceCollection AddLogging(IServiceCollection services, Action<ILoggingBuilder> configure)
        {
            services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory, LoggerFactory>());
            services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
            return services;
        }
    }
}
5. Log Messages in IndexModel (Razor Page)
Inject the logger into your Razor Page's PageModel:
csharp
KopierenBearbeiten
namespace NetCoreWebApp_Logging.Model
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError(new Exception("Error"), "Dummy error from the Loggly Guide");
        }
    }
}
6. Configure DI in Startup.cs or Program.cs
Ensure the IDepository is registered correctly in the DI container:
builder.Services.AddScoped<IDepository, Depository>();
________________________________________
Logging Levels
•	LogInformation: Logs informational messages.
•	LogWarning: Logs warnings about potential issues.
•	LogError: Logs error messages and exceptions.
•	LogCritical: Logs critical errors that affect application functionality.
________________________________________
Conclusion
This project demonstrates a clean and flexible way of configuring and using logging in ASP.NET Core with Serilog. It showcases how to use Dependency Injection to handle logging in a way that follows the Dependency Inversion Principle (DIP), keeping the code clean, modular, and testable.

