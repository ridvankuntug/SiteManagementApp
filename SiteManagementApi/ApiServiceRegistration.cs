using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SiteManagementApi
{
    public static class ApiServiceRegistration
    {
        public static IServiceCollection AddApiService(this IServiceCollection services,
               IConfiguration configuration)
        {
            services.AddHttpClient();
            return services;
        }
    }
}
