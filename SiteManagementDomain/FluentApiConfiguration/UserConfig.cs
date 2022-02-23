using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagementDomain.Entities;

namespace SiteManagementDomain.FluentApiConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);

            modelBuilder.Property(u => u.UserName).IsRequired().HasMaxLength(20);
            modelBuilder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(20);
            modelBuilder.Property(u => u.UserTc).IsRequired().HasMaxLength(11);
            modelBuilder.Property(u => u.Email).IsRequired().HasMaxLength(20);
            modelBuilder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(10);
            modelBuilder.Property(u => u.UserVehicle).IsRequired(false).HasMaxLength(20);

            modelBuilder.Ignore(u => u.Apartment);

            modelBuilder.Ignore(u => u.NormalizedUserName);
            modelBuilder.Ignore(u => u.NormalizedEmail);
            modelBuilder.Ignore(u => u.EmailConfirmed);
            modelBuilder.Ignore(u => u.SecurityStamp);
            modelBuilder.Ignore(u => u.ConcurrencyStamp);
            modelBuilder.Ignore(u => u.PhoneNumberConfirmed);
            modelBuilder.Ignore(u => u.TwoFactorEnabled);
            modelBuilder.Ignore(u => u.LockoutEnd);
            modelBuilder.Ignore(u => u.LockoutEnabled);
            modelBuilder.Ignore(u => u.AccessFailedCount);
        }
    }
}
