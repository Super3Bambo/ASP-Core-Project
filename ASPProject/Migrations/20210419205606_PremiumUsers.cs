using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPProject.Migrations
{
    public partial class PremiumUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PremiumExpiration",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PremiumTransactionID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPermium",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumExpiration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PremiumTransactionID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isPermium",
                table: "AspNetUsers");
        }
    }
}
