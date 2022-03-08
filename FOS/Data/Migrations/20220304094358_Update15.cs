using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuCategories_MenuCategoryId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuCategoryId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuCategoryId",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuCategoryId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuCategoryId",
                table: "OrderItems",
                column: "MenuCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuCategories_MenuCategoryId",
                table: "OrderItems",
                column: "MenuCategoryId",
                principalTable: "MenuCategories",
                principalColumn: "MenuCategoryId");
        }
    }
}
