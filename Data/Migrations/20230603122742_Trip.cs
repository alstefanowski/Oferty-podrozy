using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class Trip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.RenameColumn(
                name: "smoking",
                table: "TripModel",
                newName: "Smoking");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "TripModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "TripModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "TripModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Expected_arival",
                table: "TripModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TripModel");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "TripModel");

            migrationBuilder.DropColumn(
                name: "Expected_arival",
                table: "TripModel");

            migrationBuilder.RenameColumn(
                name: "Smoking",
                table: "TripModel",
                newName: "smoking");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "TripModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_TripModel_TripId",
                        column: x => x.TripId,
                        principalTable: "TripModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TripId",
                table: "Driver",
                column: "TripId");
        }
    }
}
