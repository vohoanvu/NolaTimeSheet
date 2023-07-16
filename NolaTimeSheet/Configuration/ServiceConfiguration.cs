using Microsoft.Extensions.DependencyInjection;
using NolaTimeSheet.Data;
using NolaTimeSheet.Services;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.ViewModels;

namespace NolaTimeSheet.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Here you are registering your DbContext with the DI container.
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            services.AddScoped<IProjectService, ProjectService>();
            services.AddTransient<MainViewModel>();

            return services;
        }
    }
}
