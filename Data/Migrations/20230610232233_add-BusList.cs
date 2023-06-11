using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class addBusList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusModel_TripModel_TripModelId",
                        column: x => x.TripModelId,
                        principalTable: "TripModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusModel_TripModelId",
                table: "BusModel",
                column: "TripModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusModel");
        }
    }
}
