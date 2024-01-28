using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletBankCaseStudy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Airport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Airport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IATA_CODE",
                table: "Airport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LATITUDE",
                table: "Airport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LONGITUDE",
                table: "Airport",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Airport");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Airport");

            migrationBuilder.DropColumn(
                name: "IATA_CODE",
                table: "Airport");

            migrationBuilder.DropColumn(
                name: "LATITUDE",
                table: "Airport");

            migrationBuilder.DropColumn(
                name: "LONGITUDE",
                table: "Airport");
        }
    }
}
