using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TheFantasyOlympics.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config  => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
