using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class UseresTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2 default('0001-01-01T00:00:00.0000000')", nullable: false),
                    Expected_arrival = table.Column<DateTime>(type: "datetime2 default('0001-01-01T00:00:00.0000000')", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTrip", x => x.Id);
                    table.ForeignKey("FK_UsersTrip_Users_userID", x => x.userID, "AspNetUseres", "Id");
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "UsersTrip");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

        }
    }
}
