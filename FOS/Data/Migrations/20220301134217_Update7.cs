using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    MenuItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderStatusID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOrdered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePrepared = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Prepared");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Complete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Preparing");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Delivered");
        }
    }
}
