using System;
using AstronautScheduler.Models;

namespace AstronautScheduler.Core
{
    /// <summary>
    /// ConflictNotifier is an Observer that alerts when a new task overlaps with an existing one.
    /// </summary>
    public class ConflictNotifier : ITaskObserver
    {
        public void OnConflict(Task existing, Task newTask)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Conflict] '{newTask.Description}' overlaps with existing task '{existing.Description}'.");
            Console.ResetColor();
        }
    }
}
