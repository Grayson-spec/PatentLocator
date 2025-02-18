// Logging/LoggerManager.cs
using backend.Logging;
using Microsoft.Extensions.Logging;

namespace Backend.Logging
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger _logger;

        public LoggerManager(ILogger<LoggerManager> logger)
        {
            _logger = logger;
        }

        public ILogger Logger => _logger;
    }
}