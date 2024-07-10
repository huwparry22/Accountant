using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accountant.Data.SqlServer.Migrations.Migrations
{
    public partial class UserEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserName",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
