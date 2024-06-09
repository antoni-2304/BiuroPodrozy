using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_City_DestinationCityIdCity",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_DestinationCityIdCity",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DestinationCityIdCity",
                table: "Trip");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_IdDestinationCity",
                table: "Trip",
                column: "IdDestinationCity");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_City_IdDestinationCity",
                table: "Trip",
                column: "IdDestinationCity",
                principalTable: "City",
                principalColumn: "IdCity",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_City_IdDestinationCity",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_IdDestinationCity",
                table: "Trip");

            migrationBuilder.AddColumn<int>(
                name: "DestinationCityIdCity",
                table: "Trip",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DestinationCityIdCity",
                table: "Trip",
                column: "DestinationCityIdCity");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_City_DestinationCityIdCity",
                table: "Trip",
                column: "DestinationCityIdCity",
                principalTable: "City",
                principalColumn: "IdCity");
        }
    }
}
