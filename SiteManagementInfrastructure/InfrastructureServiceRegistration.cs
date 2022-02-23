using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteManagementInfrastructure.DatabaseContext;

namespace SiteManagementInfrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
               IConfiguration configuration)
        {

            ////Sql Connection String'imizi json dosyasından çekip veritabanı bağlantı yarlarımızı yapıyoruz
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));

            return services;
        }
    }
}
