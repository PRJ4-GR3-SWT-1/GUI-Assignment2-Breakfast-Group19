using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUI_Assignment2_Breakfast_Group19.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArrivalsAtBreakfast",
                columns: table => new
                {
                    ArrivalsAtBreakfastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivalsAtBreakfast", x => x.ArrivalsAtBreakfastId);
                });

            migrationBuilder.CreateTable(
                name: "BreakfastReservations",
                columns: table => new
                {
                    BreakfastReservationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastReservations", x => x.BreakfastReservationsId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false),
                    ArrivalsAtBreakfastId = table.Column<int>(type: "int", nullable: true),
                    BreakfastReservationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_ArrivalsAtBreakfast_ArrivalsAtBreakfastId",
                        column: x => x.ArrivalsAtBreakfastId,
                        principalTable: "ArrivalsAtBreakfast",
                        principalColumn: "ArrivalsAtBreakfastId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_BreakfastReservations_BreakfastReservationsId",
                        column: x => x.BreakfastReservationsId,
                        principalTable: "BreakfastReservations",
                        principalColumn: "BreakfastReservationsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_ArrivalsAtBreakfastId",
                table: "Room",
                column: "ArrivalsAtBreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BreakfastReservationsId",
                table: "Room",
                column: "BreakfastReservationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "ArrivalsAtBreakfast");

            migrationBuilder.DropTable(
                name: "BreakfastReservations");
        }
    }
}
