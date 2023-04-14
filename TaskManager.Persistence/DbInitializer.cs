
namespace TaskManager.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TaskManagerContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
