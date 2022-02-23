using SiteManagementDomain.FluentApiConfiguration;
using SiteManagementDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SiteManagementInfrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Tablo integrasyonlarımızı Db Context'e bildiriyoruz
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfiguration(new ApartmentConfig()).
                ApplyConfiguration(new DebtConfig()).
                ApplyConfiguration(new MessageConfig()).
                ApplyConfiguration(new UserConfig());
        }

    }
}
