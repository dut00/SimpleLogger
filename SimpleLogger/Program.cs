using System;
using System.Threading;
using SimpleLogger.Loggers;

namespace SimpleLogger
{
    class Program
    {
        private readonly ILogger _logger;

        public Program()
        {
            // Configure and create logger
            var loggerBuilder = new LoggerBuilder();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("log.txt");
            //loggerBuilder.AddEventLog();

            _logger = loggerBuilder.GetLogger(this.GetType().FullName);
        }

        static void Main(string[] args)
        {
            new Program().Run(args);
        }

        private void Run(string[] args)
        {
            //_logger.Log(LogLevel.Information, "Custom message");
            //_logger.LogInformation("Information message");
            //_logger.LogDebug("Debug message");
            //_logger.LogWarning("Warning message");
            //_logger.LogError("Error message");
            //_logger.LogCritical("Critical message");


            _logger.LogInformation($"Starting...");
            _logger.LogInformation($"Started at '{DateTime.Now}");

            string user;
            string password;
            int attempts = 5;

            Console.Write("User: ");
            user = Console.ReadLine();

            _logger.LogDebug("Starting loop...");

            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();

                if (password == "123")
                {
                    Console.WriteLine("Password is correct. You are logged in.");
                    _logger.LogInformation($"User '{user}' logged in.");
                    break;
                }
                else
                {
                    attempts--;
                    if (attempts <= 0)
                    {
                        Console.WriteLine("ACCESS DEINED");
                        _logger.LogError($"User '{user}' has made 5 failed login attempts in a row.");
                        _logger.LogInformation($"User '{user}' account has been blocked");
                        break;
                    }
                    Console.WriteLine($"Password is incorrect. Try again. There are {attempts} attempt(s) left");
                    _logger.LogWarning($"User '{user}' typed incorrect password.");
                }
            } while (password != "123");

            _logger.LogDebug("Loop ended.");


            try
            {
                throw new Exception("Something went wrong!");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
            }


            _logger.LogInformation("Ending...");
            Thread.Sleep(3000);
            _logger.LogInformation($"Ended at '{DateTime.Now}");
        }
    }
}
