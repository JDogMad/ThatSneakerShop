using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frameworks_ThatSneakerShop.Data.Migrations
{
    public partial class TroubleShooting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalOrder = table.Column<float>(type: "real", nullable: false),
                    TimeOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoePrice = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.ShoeId);
                    table.ForeignKey(
                        name: "FK_Shoe_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Whislist",
                columns: table => new
                {
                    WhislistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whislist", x => x.WhislistId);
                    table.ForeignKey(
                        name: "FK_Whislist_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "ShoeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_CategoryId",
                table: "Shoe",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Whislist_ShoeId",
                table: "Whislist",
                column: "ShoeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Whislist");

            migrationBuilder.DropTable(
                name: "Shoe");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
