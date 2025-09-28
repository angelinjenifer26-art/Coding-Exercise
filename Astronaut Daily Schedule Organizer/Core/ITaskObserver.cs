using AstronautScheduler.Models;

namespace AstronautScheduler.Core
{
    /// <summary>
    /// Defines Observer contract for handling task conflicts.
    /// </summary>
    public interface ITaskObserver
    {
        void OnConflict(Task existing, Task newTask);
    }
}
