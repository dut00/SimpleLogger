using SimpleLogger.Loggers;
using SimpleLogger.Loggers.Essentials;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Loggers
{
    class Logger : ILogger
    {
        //private static Logger _instance;
        //private static Object _lock = new Object();

        //private Logger()
        //{
        //}

        //public static Logger GetInstance()
        //{
        //    lock (_lock)
        //    {
        //        return _instance ?? (_instance = new Logger());
        //    }
        //}

        //public void Log(string message)
        //{
        //    throw new NotImplementedException();
        //}

        private readonly List<ILogger> _loggers = new List<ILogger>();

        public string OriginName { get; }

        public Logger(List<ILogger> loggers, string originName)
        {
            _loggers = loggers;
            OriginName = originName;
        }


        public void Log(LogLevel logLevel, string message)
        {
            if (!String.IsNullOrEmpty(OriginName))
            {
                message = $"[{OriginName}] {message}";
            }

            foreach (var logger in _loggers)
            {
                logger.Log(logLevel, message);
            }
        }
    }
}
