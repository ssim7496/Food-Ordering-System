using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Ordered");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Prepared");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Complete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Draft");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Ordered");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Prepared");

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 4, "Complete" },
                    { 5, "Cancelled" }
                });
        }
    }
}
