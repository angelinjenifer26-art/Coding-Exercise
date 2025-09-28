using System;

namespace DesignPatternsDemo.Utils
{
    public static class MenuHelper
    {
        public static void ShowHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================================");
            Console.WriteLine($"        {title}");
            Console.WriteLine("=====================================");
            Console.ResetColor();
        }
    }
}
