using System;

namespace DesignPatternsDemo.Creational
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();
        private Logger() { }
        public static Logger Instance => instance;
        public void Log(string msg) => Console.WriteLine($"[LOG]: {msg}");
    }

    public static class SingletonDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Singleton Pattern Demo ---");
            Logger.Instance.Log("Singleton logger works.");
            Logger.Instance.Log("Only one instance exists.");
        }
    }
}
