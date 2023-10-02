namespace NetCoreWebApp_Logging.Services
{
    public interface IDepository
    {
        public  IServiceCollection AddLogging(IServiceCollection services, Action<ILoggingBuilder> configure);
        
    }
}
