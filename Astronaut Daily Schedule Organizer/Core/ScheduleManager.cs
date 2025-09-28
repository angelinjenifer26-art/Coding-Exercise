using System;
using System.Collections.Generic;
using System.Linq;
using AstronautScheduler.Models;

namespace AstronautScheduler.Core
{
    /// <summary>
    /// ScheduleManager is a Singleton class that manages all astronaut tasks.
    /// It validates new tasks, prevents conflicts, and provides CRUD operations.
    /// </summary>
    public sealed class ScheduleManager
    {
        private static readonly ScheduleManager instance = new ScheduleManager();
        private readonly List<Task> tasks = new();
        private readonly List<ITaskObserver> observers = new();

        private ScheduleManager() { }

        public static ScheduleManager Instance => instance;

        public void AddObserver(ITaskObserver observer) => observers.Add(observer);

        // Add a new task with conflict validation
        public void AddTask(Task task)
        {
            foreach (var existing in tasks)
            {
                // Conflict if times overlap
                if (!(task.End <= existing.Start || task.Start >= existing.End))
                {
                    foreach (var obs in observers) obs.OnConflict(existing, task);
                    throw new InvalidOperationException($"Task '{task.Description}' conflicts with '{existing.Description}'.");
                }
            }

            tasks.Add(task);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task added successfully.");
            Console.ResetColor();
        }

        // Remove a task by description
        public void RemoveTask(string description)
        {
            var task = tasks.FirstOrDefault(t => t.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (task == null) throw new KeyNotFoundException("Task not found.");
            tasks.Remove(task);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task removed successfully.");
            Console.ResetColor();
        }

        // View all tasks, sorted by start time
        public void ViewTasks()
        {
            if (!tasks.Any())
            {
                Console.WriteLine("No tasks scheduled for the day.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Daily Tasks ---");
            Console.ResetColor();

            foreach (var task in tasks.OrderBy(t => t.Start))
                Console.WriteLine(task);
        }

        // Mark task as completed
        public void MarkCompleted(string description)
        {
            var task = tasks.FirstOrDefault(t => t.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (task == null) throw new KeyNotFoundException("Task not found.");
            task.Completed = true;
            Console.WriteLine($"Task '{description}' marked as completed.");
        }
    }
}
