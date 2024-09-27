using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dimchev.DiceRoller.Operative.Core
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
