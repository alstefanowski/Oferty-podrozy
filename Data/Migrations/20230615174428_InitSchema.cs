using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class InitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Starting_place",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Offers",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Offers",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Starting_place",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
