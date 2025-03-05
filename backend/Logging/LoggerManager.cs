// Logging/LoggerManager.cs
using backend.Interfaces;
using backend.Logging;
using Microsoft.Extensions.Logging;

namespace backend.Logging
{
    public class LoggerManager(ILogger<LoggerManager> logger) : ILoggerManager
    {
        private readonly ILogger _logger = logger;

        public ILogger Logger => _logger;
    }
}