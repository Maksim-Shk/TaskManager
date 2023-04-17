
using Microsoft.OpenApi.Models;

namespace TaskManager.Server.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "API Менеджера задач",
                    Version = "v1.0",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Name"
                    }
                });

                c.ResolveConflictingActions(apiDesription => apiDesription.First());

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }
        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching();
        }
    }
}