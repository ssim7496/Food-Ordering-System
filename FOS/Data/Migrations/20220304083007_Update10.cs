using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemID",
                table: "OrderItems",
                column: "MenuItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemID",
                table: "OrderItems",
                column: "MenuItemID",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemID",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems");
        }
    }
}
