using Microsoft.Extensions.Logging;
using UtopiaCity.Common.Logging;

namespace UtopiaCity.Common.Extensions
{
    public static class FileLoggingExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
