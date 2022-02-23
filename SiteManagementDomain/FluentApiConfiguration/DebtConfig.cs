using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagementDomain.Entities;

namespace SiteManagementDomain.FluentApiConfiguration
{
    public class DebtConfig : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> modelBuilder)
        {
            modelBuilder.HasKey(d => d.DebtId);
            modelBuilder.Property(d => d.DebtBill).IsRequired().HasMaxLength(7);
            modelBuilder.Property(d => d.DebtDue).IsRequired().HasMaxLength(7);
            modelBuilder.Property(d => d.DebtYear).IsRequired().HasMaxLength(4);
            modelBuilder.Property(d => d.DebtMonth).IsRequired().HasMaxLength(2);
            modelBuilder.Property(d => d.IsPaid).IsRequired();


            modelBuilder.HasOne(w => w.User).WithMany(bw => bw.Debt).HasForeignKey(w => w.User_Id);
        }
    }
}
