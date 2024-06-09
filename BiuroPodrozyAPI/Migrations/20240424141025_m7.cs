using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelIdHotel",
                table: "Trip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHotel",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IdHotel",
                table: "Trip");
        }
    }
}
