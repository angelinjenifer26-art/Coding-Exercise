using System;

namespace AstronautScheduler.Models
{
    /// <summary>
    /// Factory class for creating Task objects with validation.
    /// </summary>
    public static class TaskFactory
    {
        public static Task Create(string desc, string start, string end, string priority)
        {
            if (!TimeSpan.TryParse(start, out var s) || !TimeSpan.TryParse(end, out var e))
                throw new ArgumentException("Invalid time format. Use HH:mm format.");
            if (s >= e)
                throw new ArgumentException("Start time must be earlier than End time.");

            return new Task
            {
                Description = string.IsNullOrWhiteSpace(desc) ? "Unnamed Task" : desc,
                Start = s,
                End = e,
                Priority = string.IsNullOrWhiteSpace(priority) ? "Medium" : priority,
                Completed = false
            };
        }
    }
}
