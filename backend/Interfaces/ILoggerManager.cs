using Microsoft.Extensions.Logging;

namespace backend.Interfaces
{
    public interface ILoggerManager
    {
        ILogger Logger { get; }
    }
}
