using System;

namespace AstronautScheduler.Models
{
    /// <summary>
    /// Represents a single astronaut task with timing and priority.
    /// </summary>
    public class Task
    {
        public string Description { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Priority { get; set; }
        public bool Completed { get; set; }

        public override string ToString() =>
            $"{Start:hh\\:mm} - {End:hh\\:mm}: {Description} [{Priority}] {(Completed ? \"(Done)\" : \"\")}";
    }
}
