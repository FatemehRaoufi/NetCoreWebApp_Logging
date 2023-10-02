
using NetCoreWebApp_Logging.Services;
using Serilog;//Installing: dotnet add package Serilog.AspNetCore && dotnet add package Serilog.Sinks.Console

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//-----------------------------------------
/*
 customize any aspect of the log written to Windows Event Log, 
 such as the name of the application and the source of the log (displayed as .NET Runtime by default). 
 You do this by using the appropriate overload of the AddEventLog function as follows:
 */
builder.Logging.AddEventLog(eventLogSettings =>
{
    eventLogSettings.SourceName = "LogglyGuide";
});
/*
 The configuration connects the ConsoleLoggerProvider (an ILoggerProvider) to the ILoggerFactory
 */

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders(); //clearing all the logging providers
    logging.AddConsole(); //adding the ConsoleLoggerProvider
}
);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders(); //clearing all the logging providers
    //Installing "NetEscapades.Extensions.Logging.RollingFile" from Nuget to can use AddFile() Method
    logging.AddFile(); //writing the application’s logs to a file.
}
);

//Using Serilog instead of ILoggerFactory

builder.Host.UseSerilog((context, configuration) =>
    configuration.WriteTo.Console());
//------------------------------------------
builder.Services.AddScoped<IDepository, Depository>();

//builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();


//https://www.loggly.com/ultimate-guide/net-logging-basics/

