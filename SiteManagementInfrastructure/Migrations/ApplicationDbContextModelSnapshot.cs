// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteManagementInfrastructure.DatabaseContext;

namespace SiteManagementInfrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiteManagementDomain.Entities.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentBlock")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("ApartmentFloor")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("ApartmentNo")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("ApartmentType")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("ApartmentId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("SiteManagementDomain.Entities.Debt", b =>
                {
                    b.Property<int>("DebtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("DebtBill")
                        .HasMaxLength(7)
                        .HasColumnType("real");

                    b.Property<float>("DebtDue")
                        .HasMaxLength(7)
                        .HasColumnType("real");

                    b.Property<int>("DebtMonth")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("DebtYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("DebtId");

                    b.HasIndex("User_Id");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("SiteManagementDomain.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MessageEditTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MessageSendTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(999)
                        .HasColumnType("nvarchar(999)");

                    b.Property<int>("Reciver_Id")
                        .HasColumnType("int");

                    b.Property<int>("Sender_Id")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("Reciver_Id");

                    b.HasIndex("Sender_Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SiteManagementDomain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("UserTc")
                        .HasMaxLength(11)
                        .HasColumnType("bigint");

                    b.Property<string>("UserVehicle")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("UserTc")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SiteManagementDomain.Entities.Debt", b =>
                {
                    b.HasOne("SiteManagementDomain.Entities.User", "User")
                        .WithMany("Debt")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SiteManagementDomain.Entities.Message", b =>
                {
                    b.HasOne("SiteManagementDomain.Entities.User", "Reciver_User")
                        .WithMany("Reciver_Message")
                        .HasForeignKey("Reciver_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SiteManagementDomain.Entities.User", "Sender_User")
                        .WithMany("Sender_Message")
                        .HasForeignKey("Sender_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reciver_User");

                    b.Navigation("Sender_User");
                });

            modelBuilder.Entity("SiteManagementDomain.Entities.User", b =>
                {
                    b.Navigation("Debt");

                    b.Navigation("Reciver_Message");

                    b.Navigation("Sender_Message");
                });
#pragma warning restore 612, 618
        }
    }
}
