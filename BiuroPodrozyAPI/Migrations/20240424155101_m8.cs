using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Hotel_HotelIdHotel",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_HotelIdHotel",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "HotelIdHotel",
                table: "Trip");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_IdHotel",
                table: "Trip",
                column: "IdHotel");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Hotel_IdHotel",
                table: "Trip",
                column: "IdHotel",
                principalTable: "Hotel",
                principalColumn: "IdHotel",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Hotel_IdHotel",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_IdHotel",
                table: "Trip");

            migrationBuilder.AddColumn<int>(
                name: "HotelIdHotel",
                table: "Trip",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_HotelIdHotel",
                table: "Trip",
                column: "HotelIdHotel");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Hotel_HotelIdHotel",
                table: "Trip",
                column: "HotelIdHotel",
                principalTable: "Hotel",
                principalColumn: "IdHotel");
        }
    }
}
