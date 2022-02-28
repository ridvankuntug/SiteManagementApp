using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagementInfrastructure.Migrations
{
    public partial class CleanStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentBlock = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ApartmentFloor = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    ApartmentNo = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    ApartmentType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserTc = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    UserVehicle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    DebtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtBill = table.Column<float>(type: "real", maxLength: 7, nullable: false),
                    DebtDue = table.Column<float>(type: "real", maxLength: 7, nullable: false),
                    DebtYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    DebtMonth = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.DebtId);
                    table.ForeignKey(
                        name: "FK_Debts_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(999)", maxLength: 999, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    MessageSendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageEditTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sender_Id = table.Column<int>(type: "int", nullable: false),
                    Reciver_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Users_Reciver_Id",
                        column: x => x.Reciver_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_Sender_Id",
                        column: x => x.Sender_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debts_User_Id",
                table: "Debts",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Reciver_Id",
                table: "Messages",
                column: "Reciver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Sender_Id",
                table: "Messages",
                column: "Sender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTc",
                table: "Users",
                column: "UserTc",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
