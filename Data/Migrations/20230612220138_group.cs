using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Offers",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "GroupModelId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_TripModel_TripId",
                        column: x => x.TripId,
                        principalTable: "TripModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_GroupModelId",
                table: "Offers",
                column: "GroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_TripId",
                table: "Group",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Group_GroupModelId",
                table: "Offers",
                column: "GroupModelId",
                principalTable: "Group",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Group_GroupModelId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Offers_GroupModelId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "GroupModelId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Offers",
                newName: "Username");
        }
    }
}
