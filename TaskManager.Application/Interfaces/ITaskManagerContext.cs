using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TaskManager.Domain;

namespace TaskManager.Application.Interfaces
{
    /// <summary>
    /// Используется везде
    /// </summary>
    public interface ITaskManagerContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Domain.Task> Tasks { get; set; }

    }
}
