using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Application.Interfaces
{
    /// <summary>
    /// Используется везде
    /// </summary>
    public interface ITaskManagerContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Task> Tasks { get; set; }
    }
}
