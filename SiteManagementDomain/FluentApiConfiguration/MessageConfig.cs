using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagementDomain.Entities;

namespace SiteManagementDomain.FluentApiConfiguration
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> modelBuilder)
        {
            modelBuilder.HasKey(m => m.MessageId);

            modelBuilder.Property(m => m.MessageText).IsRequired().HasMaxLength(999);
            modelBuilder.Ignore(m => m.IsNew);

            modelBuilder.HasOne(m => m.Sender_User).WithMany(m => m.Sender_Message).HasForeignKey(w => w.Sender_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.HasOne(m => m.Reciver_User).WithMany(m => m.Reciver_Message).HasForeignKey(w => w.Reciver_Id).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
