using Dimchev.DiceRoller.Operative.Core.Contracts.Persistence;
using Dimchev.DiceRoller.Operative.Core.Contracts.Services;
using Dimchev.DiceRoller.Operative.Infrastructure.Repositories;
using Dimchev.DiceRoller.Operative.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dimchev.DiceRoller.Operative.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DiceDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DiceConnectionString")));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IDiceRollRepository, DiceRollRepository>();
            services.AddScoped<IDiceRollService, DiceRollService>();

            return services;
        }
    }
}
