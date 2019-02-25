using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Loggers
{
    public interface ILoggerBuilder
    {
        ILogger GetLogger(string name);

        void AddConsole();
        void AddEventLog();
        void AddFile(string path);
    }
}
