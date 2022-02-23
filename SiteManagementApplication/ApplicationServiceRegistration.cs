using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SiteManagementApplication
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
