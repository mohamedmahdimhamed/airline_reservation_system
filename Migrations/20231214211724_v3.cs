using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boookings_Flights_FlightId",
                table: "Boookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aeroplanes_AeroplanePlaneID",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "AeroplaneAeroplaneImage");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AeroplanePlaneID",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Boookings_FlightId",
                table: "Boookings");

            migrationBuilder.DropColumn(
                name: "AeroplanePlaneID",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AdminResponse",
                table: "Boookings");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Boookings");

            migrationBuilder.DropColumn(
                name: "Airline_Company",
                table: "Aeroplanes");

            migrationBuilder.DropColumn(
                name: "AeroplaneName",
                table: "AeroplaneImages");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Boookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AeroplaneImageImageID",
                table: "Aeroplanes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AeroplaneId",
                table: "AeroplaneImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneID",
                table: "Flights",
                column: "PlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Boookings_FligthId",
                table: "Boookings",
                column: "FligthId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeroplanes_AeroplaneImageImageID",
                table: "Aeroplanes",
                column: "AeroplaneImageImageID");

            migrationBuilder.CreateIndex(
                name: "IX_AeroplaneImages_AeroplaneId",
                table: "AeroplaneImages",
                column: "AeroplaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_AeroplaneImages_Aeroplanes_AeroplaneId",
                table: "AeroplaneImages",
                column: "AeroplaneId",
                principalTable: "Aeroplanes",
                principalColumn: "PlaneID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroplanes_AeroplaneImages_AeroplaneImageImageID",
                table: "Aeroplanes",
                column: "AeroplaneImageImageID",
                principalTable: "AeroplaneImages",
                principalColumn: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Boookings_Flights_FligthId",
                table: "Boookings",
                column: "FligthId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aeroplanes_PlaneID",
                table: "Flights",
                column: "PlaneID",
                principalTable: "Aeroplanes",
                principalColumn: "PlaneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AeroplaneImages_Aeroplanes_AeroplaneId",
                table: "AeroplaneImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Aeroplanes_AeroplaneImages_AeroplaneImageImageID",
                table: "Aeroplanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boookings_Flights_FligthId",
                table: "Boookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aeroplanes_PlaneID",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneID",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Boookings_FligthId",
                table: "Boookings");

            migrationBuilder.DropIndex(
                name: "IX_Aeroplanes_AeroplaneImageImageID",
                table: "Aeroplanes");

            migrationBuilder.DropIndex(
                name: "IX_AeroplaneImages_AeroplaneId",
                table: "AeroplaneImages");

            migrationBuilder.DropColumn(
                name: "AeroplaneImageImageID",
                table: "Aeroplanes");

            migrationBuilder.DropColumn(
                name: "AeroplaneId",
                table: "AeroplaneImages");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Flights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AeroplanePlaneID",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Boookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdminResponse",
                table: "Boookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Boookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Airline_Company",
                table: "Aeroplanes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AeroplaneName",
                table: "AeroplaneImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AeroplanePlaneID",
                table: "Flights",
                column: "AeroplanePlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Boookings_FlightId",
                table: "Boookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_AeroplaneAeroplaneImage_AeroplanesPlaneID",
                table: "AeroplaneAeroplaneImage",
                column: "AeroplanesPlaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Boookings_Flights_FlightId",
                table: "Boookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aeroplanes_AeroplanePlaneID",
                table: "Flights",
                column: "AeroplanePlaneID",
                principalTable: "Aeroplanes",
                principalColumn: "PlaneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
