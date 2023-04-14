using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaskManager.Application.Interfaces;

namespace TaskManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TaskManagerContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<ITaskManagerContext>(provider =>
                provider.GetService<TaskManagerContext>());
            return services;
        }
    }
}
