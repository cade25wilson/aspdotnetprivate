using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.data.migrations
{
    public partial class Activation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    COLOR = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CATEGORY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BRAND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SHIPPINGMETHOD = table.Column<string>(name: "SHIPPING METHOD", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SHIPPINGPRICE = table.Column<decimal>(name: "SHIPPING PRICE", type: "decimal(18,2)", nullable: false),
                    SalePostedDate = table.Column<DateTime>(name: "Sale Posted Date", type: "smalldatetime", nullable: true),
                    PosterName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image5 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image6 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image7 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image8 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image9 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image10 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductActivation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
