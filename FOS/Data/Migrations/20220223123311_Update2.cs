using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOS.Data.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Customers",
                newName: "Email");
        }
    }
}
