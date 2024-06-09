using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryPhoto_Country_IdCountry",
                table: "CountryPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "IdCountry",
                table: "CountryPhoto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryPhoto_Country_IdCountry",
                table: "CountryPhoto",
                column: "IdCountry",
                principalTable: "Country",
                principalColumn: "IdCountry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryPhoto_Country_IdCountry",
                table: "CountryPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "IdCountry",
                table: "CountryPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryPhoto_Country_IdCountry",
                table: "CountryPhoto",
                column: "IdCountry",
                principalTable: "Country",
                principalColumn: "IdCountry",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
