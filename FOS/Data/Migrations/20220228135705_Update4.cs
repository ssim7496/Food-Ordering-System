using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MenuItems",
                type: "float(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<double>(
                name: "Order",
                table: "MenuItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Order",
                table: "MenuCategories",
                type: "float(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryId", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "Starters", 1.0 },
                    { 2, "Salads", 2.0 },
                    { 3, "Wraps", 3.0 },
                    { 4, "Burgers", 4.0 },
                    { 5, "Pasta", 5.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "MenuCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "MenuCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "MenuCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "MenuCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "MenuCategoryId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Order",
                table: "MenuItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "MenuCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
