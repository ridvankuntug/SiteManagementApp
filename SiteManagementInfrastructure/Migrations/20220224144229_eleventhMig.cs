using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagementInfrastructure.Migrations
{
    public partial class eleventhMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartments_User_Id",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "MessageTime",
                table: "Messages",
                newName: "MessageSendTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageEditTime",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageEditTime",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "MessageSendTime",
                table: "Messages",
                newName: "MessageTime");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_User_Id",
                table: "Apartments",
                column: "User_Id",
                unique: true);
        }
    }
}
