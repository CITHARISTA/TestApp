using App.Core.Abstracts;
using App.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Config
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
