using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AdminMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "AeroplaneImages",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AeroplaneName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AeroplaneImages", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineCompanies",
                columns: table => new
                {
                    AirlineCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineCompanies", x => x.AirlineCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Aeroplanes",
                columns: table => new
                {
                    PlaneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AeroplaneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Airline_Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirlineCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroplanes", x => x.PlaneID);
                    table.ForeignKey(
                        name: "FK_Aeroplanes_AirlineCompanies_AirlineCompanyId",
                        column: x => x.AirlineCompanyId,
                        principalTable: "AirlineCompanies",
                        principalColumn: "AirlineCompanyId");
                });

            migrationBuilder.CreateTable(
                name: "AeroplaneAeroplaneImage",
                columns: table => new
                {
                    AeroplaneImagesImageID = table.Column<int>(type: "int", nullable: false),
                    AeroplanesPlaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AeroplaneAeroplaneImage", x => new { x.AeroplaneImagesImageID, x.AeroplanesPlaneID });
                    table.ForeignKey(
                        name: "FK_AeroplaneAeroplaneImage_AeroplaneImages_AeroplaneImagesImageID",
                        column: x => x.AeroplaneImagesImageID,
                        principalTable: "AeroplaneImages",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AeroplaneAeroplaneImage_Aeroplanes_AeroplanesPlaneID",
                        column: x => x.AeroplanesPlaneID,
                        principalTable: "Aeroplanes",
                        principalColumn: "PlaneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaneID = table.Column<int>(type: "int", nullable: true),
                    AircraftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: true),
                    AvailableSeats = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AeroplanePlaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Aeroplanes_AeroplanePlaneID",
                        column: x => x.AeroplanePlaneID,
                        principalTable: "Aeroplanes",
                        principalColumn: "PlaneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Passport = table.Column<int>(type: "int", nullable: false),
                    FligthId = table.Column<int>(type: "int", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdminResponse = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Boookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AeroplaneAeroplaneImage_AeroplanesPlaneID",
                table: "AeroplaneAeroplaneImage",
                column: "AeroplanesPlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Aeroplanes_AirlineCompanyId",
                table: "Aeroplanes",
                column: "AirlineCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Boookings_FlightId",
                table: "Boookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Boookings_UserId",
                table: "Boookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AeroplanePlaneID",
                table: "Flights",
                column: "AeroplanePlaneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AeroplaneAeroplaneImage");

            migrationBuilder.DropTable(
                name: "Boookings");

            migrationBuilder.DropTable(
                name: "AeroplaneImages");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Aeroplanes");

            migrationBuilder.DropTable(
                name: "AirlineCompanies");
        }
    }
}
