using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecSys.Data.Migrations
{
    public partial class Initilize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UkRetailOriginalSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    StockCode = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UkRetailOriginalSales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UkRetailOriginalSales");
        }
    }
}
