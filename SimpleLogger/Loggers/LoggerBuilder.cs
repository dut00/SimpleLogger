using SimpleLogger.Loggers.Essentials;
using System;
using System.Collections.Generic;

namespace SimpleLogger.Loggers
{
    public class LoggerBuilder : ILoggerBuilder
    {
        private List<ILogger> _loggers = new List<ILogger>();

        public ILogger GetLogger()
        {
            return this.GetLogger("");
        }

        public ILogger GetLogger(string sourceName)
        {
            if(_loggers.Count == 0)
            {
                throw new Exception("The logger targets must be defined");
            }

            return new Logger(_loggers, sourceName);
        }

        // Adds new log target
        // It allows to add only unique types of loggers
        private void AddLogger(ILogger logger)
        {
            if (!_loggers.Exists(x => x.GetType() == logger.GetType()))
            {
                _loggers.Add(logger);
                //Console.WriteLine($"Added log target: {logger.GetType()}");
            }
        }


        public void AddConsole()
        {
            AddLogger(new ConsoleLogger());
        }

        public void AddFile(string path)
        {
            AddLogger(new FileLogger(path));
        }

        public void AddEventLog()
        {
            AddLogger(new EventLogLogger());
        }
    }
}