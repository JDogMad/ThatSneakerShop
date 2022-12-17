﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frameworks_ThatSneakerShop.Data.Migrations
{
    public partial class UpdateTheCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Category");
        }
    }
}
