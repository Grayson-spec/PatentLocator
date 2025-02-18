// Logging/ILoggerManager.cs
using Microsoft.Extensions.Logging;

namespace backend.Logging
{
    public interface ILoggerManager
    {
        ILogger Logger { get; }
    }
}