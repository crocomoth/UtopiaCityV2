using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace UtopiaCity.Common.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string path;
        private static readonly object lockObj = new object();

        public FileLogger(string filePath)
        {
            path = filePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (lockObj)
                {
                    File.AppendAllText(path, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
