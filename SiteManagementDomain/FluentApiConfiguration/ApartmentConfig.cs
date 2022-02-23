using Microsoft.EntityFrameworkCore;
using SiteManagementDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SiteManagementDomain.FluentApiConfiguration
{
    public class ApartmentConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> modelBuilder)
        {
            modelBuilder.HasKey(a => a.ApartmentId);

            modelBuilder.Property(a => a.ApartmentBlock).IsRequired().HasMaxLength(3);
            modelBuilder.Property(a => a.ApartmentFloor).IsRequired().HasMaxLength(2);
            modelBuilder.Property(a => a.ApartmentNo).IsRequired().HasMaxLength(3);
            modelBuilder.Property(a => a.ApartmentType).IsRequired().HasMaxLength(3);

            modelBuilder.Ignore(a => a.OwnerName);

            modelBuilder.HasIndex(u => u.User_Id).IsUnique()
                .Metadata.SetAnnotation(RelationalAnnotationNames.Filter, null);
            modelBuilder.Property(a => a.User_Id).IsRequired(false);

            modelBuilder.Ignore(a => a.User);
            //modelBuilder.HasOne(a => a.User)
            //    .WithOne(u => u.Apartment)
            //    .HasForeignKey<Apartment>(a => a.User_Id)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
