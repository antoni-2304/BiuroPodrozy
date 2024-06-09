using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Service_Reservation_ReservationIdReservation",
                table: "Reservation_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Service_Service_ServiceIdService",
                table: "Reservation_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_TripPhoto_TripPhoto_TripPhotoIdTripPhoto",
                table: "Trip_TripPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_TripPhoto_Trip_TripIdTrip",
                table: "Trip_TripPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip_TripPhoto",
                table: "Trip_TripPhoto");

            migrationBuilder.DropIndex(
                name: "IX_Trip_TripPhoto_TripIdTrip",
                table: "Trip_TripPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation_Service",
                table: "Reservation_Service");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Service_ReservationIdReservation",
                table: "Reservation_Service");

            migrationBuilder.DropColumn(
                name: "IdTrip_TripPhoto",
                table: "Trip_TripPhoto");

            migrationBuilder.DropColumn(
                name: "IdTrip",
                table: "Trip_TripPhoto");

            migrationBuilder.DropColumn(
                name: "IdTripPhoto",
                table: "Trip_TripPhoto");

            migrationBuilder.DropColumn(
                name: "IdReservation_Service",
                table: "Reservation_Service");

            migrationBuilder.DropColumn(
                name: "IdReservation",
                table: "Reservation_Service");

            migrationBuilder.DropColumn(
                name: "IdService",
                table: "Reservation_Service");

            migrationBuilder.RenameColumn(
                name: "TripPhotoIdTripPhoto",
                table: "Trip_TripPhoto",
                newName: "TripsIdTrip");

            migrationBuilder.RenameColumn(
                name: "TripIdTrip",
                table: "Trip_TripPhoto",
                newName: "TripPhotosIdTripPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_TripPhoto_TripPhotoIdTripPhoto",
                table: "Trip_TripPhoto",
                newName: "IX_Trip_TripPhoto_TripsIdTrip");

            migrationBuilder.RenameColumn(
                name: "ServiceIdService",
                table: "Reservation_Service",
                newName: "ServicesIdService");

            migrationBuilder.RenameColumn(
                name: "ReservationIdReservation",
                table: "Reservation_Service",
                newName: "ReservationsIdReservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_Service_ServiceIdService",
                table: "Reservation_Service",
                newName: "IX_Reservation_Service_ServicesIdService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip_TripPhoto",
                table: "Trip_TripPhoto",
                columns: new[] { "TripPhotosIdTripPhoto", "TripsIdTrip" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation_Service",
                table: "Reservation_Service",
                columns: new[] { "ReservationsIdReservation", "ServicesIdService" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Service_Reservation_ReservationsIdReservation",
                table: "Reservation_Service",
                column: "ReservationsIdReservation",
                principalTable: "Reservation",
                principalColumn: "IdReservation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Service_Service_ServicesIdService",
                table: "Reservation_Service",
                column: "ServicesIdService",
                principalTable: "Service",
                principalColumn: "IdService",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_TripPhoto_TripPhoto_TripPhotosIdTripPhoto",
                table: "Trip_TripPhoto",
                column: "TripPhotosIdTripPhoto",
                principalTable: "TripPhoto",
                principalColumn: "IdTripPhoto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_TripPhoto_Trip_TripsIdTrip",
                table: "Trip_TripPhoto",
                column: "TripsIdTrip",
                principalTable: "Trip",
                principalColumn: "IdTrip",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Service_Reservation_ReservationsIdReservation",
                table: "Reservation_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Service_Service_ServicesIdService",
                table: "Reservation_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_TripPhoto_TripPhoto_TripPhotosIdTripPhoto",
                table: "Trip_TripPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_TripPhoto_Trip_TripsIdTrip",
                table: "Trip_TripPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip_TripPhoto",
                table: "Trip_TripPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation_Service",
                table: "Reservation_Service");

            migrationBuilder.RenameColumn(
                name: "TripsIdTrip",
                table: "Trip_TripPhoto",
                newName: "TripPhotoIdTripPhoto");

            migrationBuilder.RenameColumn(
                name: "TripPhotosIdTripPhoto",
                table: "Trip_TripPhoto",
                newName: "TripIdTrip");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_TripPhoto_TripsIdTrip",
                table: "Trip_TripPhoto",
                newName: "IX_Trip_TripPhoto_TripPhotoIdTripPhoto");

            migrationBuilder.RenameColumn(
                name: "ServicesIdService",
                table: "Reservation_Service",
                newName: "ServiceIdService");

            migrationBuilder.RenameColumn(
                name: "ReservationsIdReservation",
                table: "Reservation_Service",
                newName: "ReservationIdReservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_Service_ServicesIdService",
                table: "Reservation_Service",
                newName: "IX_Reservation_Service_ServiceIdService");

            migrationBuilder.AddColumn<int>(
                name: "IdTrip_TripPhoto",
                table: "Trip_TripPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdTrip",
                table: "Trip_TripPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTripPhoto",
                table: "Trip_TripPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReservation_Service",
                table: "Reservation_Service",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdReservation",
                table: "Reservation_Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdService",
                table: "Reservation_Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip_TripPhoto",
                table: "Trip_TripPhoto",
                column: "IdTrip_TripPhoto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation_Service",
                table: "Reservation_Service",
                column: "IdReservation_Service");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripPhoto_TripIdTrip",
                table: "Trip_TripPhoto",
                column: "TripIdTrip");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Service_ReservationIdReservation",
                table: "Reservation_Service",
                column: "ReservationIdReservation");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Service_Reservation_ReservationIdReservation",
                table: "Reservation_Service",
                column: "ReservationIdReservation",
                principalTable: "Reservation",
                principalColumn: "IdReservation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Service_Service_ServiceIdService",
                table: "Reservation_Service",
                column: "ServiceIdService",
                principalTable: "Service",
                principalColumn: "IdService",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_TripPhoto_TripPhoto_TripPhotoIdTripPhoto",
                table: "Trip_TripPhoto",
                column: "TripPhotoIdTripPhoto",
                principalTable: "TripPhoto",
                principalColumn: "IdTripPhoto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_TripPhoto_Trip_TripIdTrip",
                table: "Trip_TripPhoto",
                column: "TripIdTrip",
                principalTable: "Trip",
                principalColumn: "IdTrip",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
