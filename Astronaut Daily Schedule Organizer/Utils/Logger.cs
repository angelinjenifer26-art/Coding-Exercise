using System;

namespace AstronautScheduler.Utils
{
    /// <summary>
    /// Singleton Logger for application-level logging.
    /// </summary>
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();
        private Logger() { }
        public static Logger Instance => instance;

        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[LOG {DateTime.Now:HH:mm:ss}] {message}");
            Console.ResetColor();
        }
    }
}
