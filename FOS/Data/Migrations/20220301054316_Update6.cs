using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "MenuCategoryId", "Name", "Order", "Price", "Visible" },
                values: new object[,]
                {
                    { 1, "Nachos guacamole Nachos layered with cheddar cheese, jalapenos, sour cream, fresh salsa and guacamole", 1, "Nachos", 1.0, 75.0, true },
                    { 2, "Marinated grilled chicken wings prepared in your choice of sauce, per-peri, lemon and herb or barbeque", 1, "Grilled chicken wings", 2.0, 70.0, true },
                    { 3, "Chicken livers pan seared with chilli, garlic, ginger, napped with a creamy tomato sauce served with bruschetta", 1, "Chicken Livers Peri-Peri", 3.0, 58.0, true },
                    { 4, "Tomato, onion, cucumber, peppers, feta cheese and olives", 2, "Greek Salad", 1.0, 68.0, true },
                    { 5, "Avocado and prawns served with a tantalizing seafood dressing", 2, "Avocado and prawn salad", 2.0, 125.0, true },
                    { 6, "Beef strips, stir fried vegetables prepared in a peri-peri sauce", 3, "Beef wrap", 1.0, 98.0, true },
                    { 7, "Strips of tender chicken fillet sautéed with fresh peppers, halloumi cheese and sweet and sour sauce", 3, "Chicken wrap", 2.0, 96.0, true },
                    { 8, "Homemade beef patty topped with crispy bacon, tempura onions, avocado guacamole, smoky cheddar, home-made tomato salsa and fresh rocket", 4, "Famous burger", 1.0, 143.0, true },
                    { 9, "Chicken Fillet topped with fresh pineapple and sweet chilli basting", 4, "Chicken cheese & pineapple", 2.0, 108.0, true },
                    { 10, "Fried mushroom and ham in a creamy garlic sauce", 5, "Pasta alfredo", 1.0, 105.0, true },
                    { 11, "Grilled prawns finished with a chilli infused creamy tomato sauce", 5, "Prawn pasta", 2.0, 135.0, true },
                    { 12, "Char grilled chicken strips pan fried with white wine, garlic mushroom and a creamy pesto sauce", 5, "Pesto chicken", 3.0, 125.0, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12);
        }
    }
}
