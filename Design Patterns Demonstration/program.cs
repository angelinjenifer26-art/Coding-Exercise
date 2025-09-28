using System;
using DesignPatternsDemo.Behavioral;
using DesignPatternsDemo.Creational;
using DesignPatternsDemo.Structural;
using DesignPatternsDemo.Utils;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Design Patterns Demonstration";
            MenuHelper.ShowHeader("DESIGN PATTERNS DEMO");

            while (true)
            {
                Console.WriteLine("\nSelect a Pattern to Demonstrate:");
                Console.WriteLine("1. Observer Pattern (Behavioral)");
                Console.WriteLine("2. Strategy Pattern (Behavioral)");
                Console.WriteLine("3. Singleton Pattern (Creational)");
                Console.WriteLine("4. Factory Pattern (Creational)");
                Console.WriteLine("5. Adapter Pattern (Structural)");
                Console.WriteLine("6. Decorator Pattern (Structural)");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter choice: ");
                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1": ObserverDemo.Run(); break;
                        case "2": StrategyDemo.Run(); break;
                        case "3": SingletonDemo.Run(); break;
                        case "4": FactoryDemo.Run(); break;
                        case "5": AdapterDemo.Run(); break;
                        case "6": DecoratorDemo.Run(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice. Try again."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error]: {ex.Message}");
                }
            }
        }
    }
}
