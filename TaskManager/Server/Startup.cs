using System.Text;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using TaskManager.Persistence;

namespace TaskManager.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["DbConnection"];
            services.AddDbContext<TaskManagerContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddPersistence(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseDeveloperExceptionPage();
            }
            else { app.UseHsts(); }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
