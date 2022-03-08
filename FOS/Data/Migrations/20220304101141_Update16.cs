using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusID",
                table: "Orders",
                column: "OrderStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusID",
                table: "Orders",
                column: "OrderStatusID",
                principalTable: "OrderStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusID",
                table: "Orders");
        }
    }
}
