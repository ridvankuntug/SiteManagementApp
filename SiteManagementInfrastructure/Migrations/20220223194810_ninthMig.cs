using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagementInfrastructure.Migrations
{
    public partial class ninthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtPeriod",
                table: "Debts");

            migrationBuilder.AddColumn<int>(
                name: "DebtMonth",
                table: "Debts",
                type: "int",
                maxLength: 2,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebtYear",
                table: "Debts",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtMonth",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "DebtYear",
                table: "Debts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DebtPeriod",
                table: "Debts",
                type: "datetime2",
                maxLength: 7,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
