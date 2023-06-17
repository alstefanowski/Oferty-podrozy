using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Group_GroupModelId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_GroupModelId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "GroupModelId",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Group",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "GroupModelId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_GroupModelId",
                table: "Offers",
                column: "GroupModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Group_GroupModelId",
                table: "Offers",
                column: "GroupModelId",
                principalTable: "Group",
                principalColumn: "Id");
        }
    }
}
