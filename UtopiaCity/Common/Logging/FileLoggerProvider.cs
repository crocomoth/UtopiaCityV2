using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Common.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _path;
        private ConcurrentDictionary<string, FileLogger> _loggers = new ConcurrentDictionary<string, FileLogger>();

        public FileLoggerProvider(string path)
        {
            _path = path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            var logger = _loggers.GetOrAdd(categoryName, name => new FileLogger(_path));
            return logger;
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
