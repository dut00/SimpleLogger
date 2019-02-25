using System;
using System.Diagnostics;

namespace SimpleLogger.Loggers.Essentials
{
    class EventLogLogger : ILogger
    {
        private readonly EventLog _eventLog;

        public EventLogLogger()
        {
            try
            {
                if (!EventLog.SourceExists("SimpleLogger"))
                {
                    // https://docs.microsoft.com/pl-pl/dotnet/api/system.diagnostics.eventlog?view=netcore-2.2

                    EventLog.CreateEventSource("SimpleLogger", "MyPlayground");
                    //return;
                }

                _eventLog = new EventLog
                {
                    Source = "SimpleLogger"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try to run the program as an Administrator.");
            }
        }

        public void Log(LogLevel logLevel, string message)
        {
            var level = EventLogEntryType.Information;

            switch (logLevel)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                    level = EventLogEntryType.Error;
                    break;
                case LogLevel.Debug:
                case LogLevel.Information:
                    level = EventLogEntryType.Information;
                    break;
                case LogLevel.Warning:
                    level = EventLogEntryType.Warning;
                    break;
                default:
                    throw new Exception($"Unsupported log level: {logLevel}");
            }

            _eventLog.WriteEntry(message, level);
        }
    }
}
