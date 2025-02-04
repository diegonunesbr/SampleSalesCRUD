using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sales2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Users_userId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_Products_productId",
                table: "SaleItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItem_Sale_saleId",
                table: "SaleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleItem",
                table: "SaleItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.RenameTable(
                name: "SaleItem",
                newName: "SaleItems");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItem_productId",
                table: "SaleItems",
                newName: "IX_SaleItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_userId",
                table: "Sales",
                newName: "IX_Sales_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleItems",
                table: "SaleItems",
                columns: new[] { "saleId", "productId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Products_productId",
                table: "SaleItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Sales_saleId",
                table: "SaleItems",
                column: "saleId",
                principalTable: "Sales",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_userId",
                table: "Sales",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Products_productId",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Sales_saleId",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_userId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleItems",
                table: "SaleItems");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "SaleItems",
                newName: "SaleItem");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_userId",
                table: "Sale",
                newName: "IX_Sale_userId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_productId",
                table: "SaleItem",
                newName: "IX_SaleItem_productId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleItem",
                table: "SaleItem",
                columns: new[] { "saleId", "productId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Users_userId",
                table: "Sale",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_Products_productId",
                table: "SaleItem",
                column: "productId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItem_Sale_saleId",
                table: "SaleItem",
                column: "saleId",
                principalTable: "Sale",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
