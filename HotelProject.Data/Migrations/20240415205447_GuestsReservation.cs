using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class GuestsReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestReservations_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "FirstName", "LastName", "PersonalNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Nikoloz", "Chkhartishvili", "01024085083", "555337681" },
                    { 2, "Khatia", "Burduli", "01024082203", "579057747" },
                    { 3, "Erekle", "Davitashvili", "12345678947", "571058998" },
                    { 4, "Dali", "Goderdzishvili", "87005633698", "555887469" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 0, 54, 47, 275, DateTimeKind.Local).AddTicks(8785), new DateTime(2024, 4, 26, 0, 54, 47, 275, DateTimeKind.Local).AddTicks(8795) },
                    { 2, new DateTime(2024, 4, 16, 0, 54, 47, 275, DateTimeKind.Local).AddTicks(8801), new DateTime(2024, 5, 16, 0, 54, 47, 275, DateTimeKind.Local).AddTicks(8802) },
                    { 3, new DateTime(2024, 4, 16, 0, 54, 47, 275, DateTimeKind.Local).AddTicks(8824), new DateTime(2024, 5, 6, 0, 54, 47, 275, DateTimeKind.Local).AddTicks(8825) }
                });

            migrationBuilder.InsertData(
                table: "GuestReservations",
                columns: new[] { "Id", "GuestId", "ReservationId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestReservations_GuestId",
                table: "GuestReservations",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestReservations_ReservationId",
                table: "GuestReservations",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestReservations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
