using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Loggers
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, string message);//, string originName); 
    }
}
