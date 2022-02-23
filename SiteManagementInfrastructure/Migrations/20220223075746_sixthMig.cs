using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagementInfrastructure.Migrations
{
    public partial class sixthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Apartments_User_Id",
                table: "Apartments",
                column: "User_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Apartments_User_Id",
                table: "Apartments");
        }
    }
}
