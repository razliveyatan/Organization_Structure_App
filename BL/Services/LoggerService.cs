using BL.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class LoggerService
    {
        private readonly ILogger _logger;
        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }
        public void LogError(string message , string className, string methodName)
        {
            string logMessage = $"Error occurred in {className}.{methodName}: {message}";
            _logger.Log(logMessage);
        }
    }
}
