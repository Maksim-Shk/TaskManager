using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
