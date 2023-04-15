using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Application.Interfaces
{
    /// <summary>
    /// ������������ �����
    /// </summary>
    public interface ITaskManagerContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Task> Tasks { get; set; }
    }
}
