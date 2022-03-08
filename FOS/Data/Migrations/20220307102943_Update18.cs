using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "Order",
                value: 4.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "Order",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "Order",
                value: 6.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "Order",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "Order",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "Order",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "Order",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "Order",
                value: 11.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "Order",
                value: 12.0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuCategoryId",
                table: "MenuItems",
                column: "MenuCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuCategories_MenuCategoryId",
                table: "MenuItems",
                column: "MenuCategoryId",
                principalTable: "MenuCategories",
                principalColumn: "MenuCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuCategories_MenuCategoryId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuCategoryId",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "Order",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "Order",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "Order",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "Order",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "Order",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "Order",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "Order",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "Order",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "Order",
                value: 3.0);
        }
    }
}
