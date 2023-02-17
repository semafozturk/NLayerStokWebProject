using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class initializ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    purchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    salePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    purchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purchasesQuantity = table.Column<int>(type: "int", nullable: false),
                    purchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.purchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    saleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesQuantity = table.Column<int>(type: "int", nullable: false),
                    saleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.saleId);
                    table.ForeignKey(
                        name: "FK_Sales_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 1, "Motor Parçası" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 2, "Araba Parçası" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "categoryId", "productName", "purchasePrice", "salePrice", "stock" },
                values: new object[,]
                {
                    { 1, 1, "YZFR5 Monster Kafa Karenajı", 520m, 750m, 4 },
                    { 2, 1, "FZ8 Fazer Debriyaj Balatası", 270m, 330m, 8 },
                    { 3, 2, "BMW E4 Klima Radyatörü", 550m, 650m, 5 },
                    { 4, 2, "FIAT Linea Motor Takozu", 290m, 370m, 10 },
                    { 5, 2, "Range Rover Triger Kayışı", 160m, 240m, 14 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "purchaseId", "comment", "productId", "purchaseDate", "purchasesQuantity" },
                values: new object[] { 1, "AXC Araba parçaları ile haftalık alım anlaşması yaptık. Konuştuğum kişi : Mehmet abi.", 3, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "saleId", "comment", "productId", "saleDate", "salesQuantity" },
                values: new object[,]
                {
                    { 1, "Ahmet abiye satış yapıldı.vsvsvs", 1, new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, null, 4, new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, null, 5, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_productId",
                table: "Purchases",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_productId",
                table: "Sales",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
