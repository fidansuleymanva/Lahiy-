﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGrids.Migrations
{
    public partial class SmallBanner2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmallBanners2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallBanners2", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmallBanners2");
        }
    }
}
