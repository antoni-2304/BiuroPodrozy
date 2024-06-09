using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiuroPodrozyAPI.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TripName",
                table: "Trip",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripName",
                table: "Trip");
        }
    }
}
