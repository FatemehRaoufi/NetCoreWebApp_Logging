
/*
Let’s cover the ASP.NET Core logging framework constructs:

ILogger: This interface provides the Log() method, which can be used to write a log message.
ILoggerProvider: Logging providers implement this interface to write the logs to a specific destination. For example, the Console ILoggerProvider writes the logs to the console. This interface is used to create a custom instance of an ILogger.
ILoggerFactory: This interface registers one or more ILoggerProvider instances 
and provides the CreateLogger() method used to create an instance of ILogger. 
The factory enables a one-to-many association between the ILogger and the ILoggerProvider instances. 
When calling the Log() method, the log is written to every registered provider.
*/

//Useful links:

//https://medium.com/@stavsofer/structured-logging-and-logs-management-asp-net-core-serilog-seq-61109f740696
//https://www.infoworld.com/article/3624022/how-to-use-advanced-serilog-features-in-aspnet-core-mvc.html
//https://dotnetcoretutorials.com/logging-asp-net-core/?expand_article=1