using Microsoft.AspNetCore.Mvc.RazorPages;

/*
 Let’s inject an ILogger instance to the IndexModel of the Index.cshtml Razor page of our application and write a custom log message:
 */
namespace NetCoreWebApp_Logging.Model
{
    /// <summary>
    /// Injecting an ILogger instance to the IndexModel of the Index.cshtml Razor page of our application and write a custom log message.
    /// if you provide an Exception object to the logging function, it will log the exception in addition to the message.
    /// Apart from the LogInformation method, ILogger defines the LogWarning and LogError extension methods, which apply the correct log level to the log message.
    /// </summary>
    public class IndexModel : PageModel
    {
        //The event category specifies the component creating the log. When you use the ILogger<T> instance to write a log,
        //the category is set to the fully qualified name of the type T using the ILogger
        private readonly ILogger<IndexModel> _logger;
      
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        
        public void OnGet()
        {
            //_logger.LogInformation("This is a custom message from the Loggly Guide"); // Used ILogger
            _logger.LogError(new Exception("Error"), "Dummy error from the Loggly Guide"); // Used Serilog


            /*
            _logger.LogInformation("Log message generated with INFORMATION severity level.");
            _logger.LogWarning("Log message generated with WARNING severity level.");
            _logger.LogError("Log message generated with ERROR severity level.");
            _logger.LogCritical("Log message log generated with CRITICAL severity level.");
            */
        }
        

        /*
         //Error trapping
        public void OnGet()
        {
            decimal result = 0;
            int num1 = 1;
            int num2 = 0;

            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                _logger.LogError(e.Message); // Err: Attempt to divide by zero
            }
        }
        */
        //Using third-party custom libraries
        /*
        public void OnGet()
        {
            decimal result = 0;
            int num1 = 1;
            int num2 = 0;

            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError(ex, message:"Error"); //Err: Error
            }
        }
       */
    }
}
