using System;
using AstronautScheduler.Core;
using AstronautScheduler.Models;
using AstronautScheduler.Utils;

namespace AstronautScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Astronaut Daily Schedule Organizer";

            // Initialize Logger and Schedule Manager
            Logger.Instance.Log("Application Started.");
            var manager = ScheduleManager.Instance;
            manager.AddObserver(new ConflictNotifier());  // Register observer for conflicts

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n====== Astronaut Scheduler ======");
                Console.ResetColor();

                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View All Tasks");
                Console.WriteLine("4. Mark Task as Completed");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine()?.Trim() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1": AddTask(manager); break;
                        case "2": RemoveTask(manager); break;
                        case "3": manager.ViewTasks(); break;
                        case "4": MarkCompleted(manager); break;
                        case "0":
                            Logger.Instance.Log("Application Exited.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Error Handling with Logging
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    Logger.Instance.Log($"Error: {ex.Message}");
                }
            }
        }

        // Method to add new task
        private static void AddTask(ScheduleManager manager)
        {
            Console.Write("Enter Description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter Start Time (HH:mm): ");
            string start = Console.ReadLine();

            Console.Write("Enter End Time (HH:mm): ");
            string end = Console.ReadLine();

            Console.Write("Enter Priority (High/Medium/Low): ");
            string priority = Console.ReadLine();

            var task = TaskFactory.Create(desc, start, end, priority);
            manager.AddTask(task);
        }

        // Method to remove task
        private static void RemoveTask(ScheduleManager manager)
        {
            Console.Write("Enter Task Description to Remove: ");
            string desc = Console.ReadLine();
            manager.RemoveTask(desc);
        }

        // Method to mark task as completed
        private static void MarkCompleted(ScheduleManager manager)
        {
            Console.Write("Enter Task Description to Mark as Completed: ");
            string desc = Console.ReadLine();
            manager.MarkCompleted(desc);
        }
    }
}
