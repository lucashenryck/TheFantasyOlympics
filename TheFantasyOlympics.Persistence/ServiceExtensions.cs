using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;
using TheFantasyOlympics.Persistence.Repositories;

namespace TheFantasyOlympics.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistanceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IAthleteRepository, AthleteRepository>();
        }
    }
}
