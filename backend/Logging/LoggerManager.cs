using backend.Interfaces;
using Microsoft.Extensions.Logging;

namespace backend.Logging
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
