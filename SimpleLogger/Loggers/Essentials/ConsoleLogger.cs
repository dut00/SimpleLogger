using System;

namespace SimpleLogger.Loggers.Essentials
{
    class ConsoleLogger : ILogger
    {
        public void Log(LogLevel logLevel, string message)
        {
            string level;

            switch (logLevel)
            {
                case LogLevel.Critical:
                    level = "CRIT";
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Debug:
                    level = "DBUG";
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Error:
                    level = "ERRR";
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Information:
                    level = "INFO";
                    break;
                case LogLevel.Warning:
                    level = "WARN";
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    throw new Exception($"Unsupported log level: {logLevel}");
            }

            Console.Write(level);
            Console.ResetColor();

            Console.WriteLine($": {message}");
        }
    }
}