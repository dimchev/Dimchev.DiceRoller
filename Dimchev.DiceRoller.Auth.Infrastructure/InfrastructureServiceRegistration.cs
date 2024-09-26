using Dimchev.DiceRoller.Auth.Core.Contracts.Persistence;
using Dimchev.DiceRoller.Auth.Core.Contracts.Services;
using Dimchev.DiceRoller.Auth.Infrastructure.Repositories;
using Dimchev.DiceRoller.Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dimchev.DiceRoller.Auth.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("AuthConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHashingService, HashingService>();
            services.AddSingleton(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
            services.AddSingleton<ITokenService, JwtTokenService>();

            return services;
        }
    }
}
