using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frameworks_ThatSneakerShop.Data.Migrations
{
    public partial class AddBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Whislist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Shoe",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Whislist");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Payment");
        }
    }
}
