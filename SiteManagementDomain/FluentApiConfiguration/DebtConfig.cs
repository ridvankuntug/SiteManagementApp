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
            modelBuilder.Property(d => d.DebtPeriod).IsRequired().HasMaxLength(7);


            modelBuilder.HasOne(w => w.User).WithMany(bw => bw.Debt).HasForeignKey(w => w.User_Id);
        }
    }
}
