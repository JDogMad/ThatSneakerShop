using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frameworks_ThatSneakerShop.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfPayment",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "TotalOrder",
                table: "Payment",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfPayment",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TotalOrder",
                table: "Payment");
        }
    }
}
