using System;
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tID = table.Column<int>(type: "int", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Starting_place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expected_arrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTrip", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tID",
                table: "UsersTrip");

            migrationBuilder.AddColumn<DateTime>(
                    name: "Departure",
                    table: "UsersTrip",
                    type: "datetime2",
                    nullable: false,
                    defaultValue: DateTime.MinValue);

            migrationBuilder.AddColumn<DateTime>(
                name: "Expected_arrival",
                table: "UsersTrip",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.MinValue);

            migrationBuilder.AlterColumn<string>(
                name: "Starting_place",
                table: "UsersTrip",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: false,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "UsersTrip",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: false,
                oldDefaultValue: "");

            migrationBuilder.DropPrimaryKey("PK_UsersTrip", "UsersTrip");
        }
    }
}
