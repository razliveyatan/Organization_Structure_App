using BL.IServices;

namespace BL.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILoggerService _logger;
        public LoggerService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            string logMessage = $"Error occurred in {message}";
            _logger.Log(logMessage);
        }

        public void LogError(string message , string className, string methodName)
        {
            string logMessage = $"Error occurred in {className}.{methodName}: {message}";
            _logger.Log(logMessage);
        }
    }
}
