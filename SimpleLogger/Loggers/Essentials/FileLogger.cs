using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleLogger.Loggers.Essentials
{
    // Add proxy patern? hmm....

    class FileLogger : ILogger
    {
        private readonly object _x = new object();
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void Log(LogLevel logLevel, string message)
        {
            string level = "INFO";
            switch (logLevel)
            {
                case LogLevel.Critical:
                    level = "CRIT";
                    break;
                case LogLevel.Debug:
                    level = "DBUG";
                    break;
                case LogLevel.Error:
                    level = "ERRR";
                    break;
                case LogLevel.Information:
                    level = "INFO";
                    break;
                case LogLevel.Warning:
                    level = "WARN";
                    break;
                default:
                    break;
            }

            message = $"{DateTime.Now.ToString()} {level} {message}";
                                   
            try
            {
                lock(_x)
                {
                    using (StreamWriter sw = new StreamWriter(_path, true))
                    {
                        sw.WriteLine(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
