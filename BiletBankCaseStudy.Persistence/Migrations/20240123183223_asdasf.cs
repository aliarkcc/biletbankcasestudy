using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletBankCaseStudy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asdasf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_Id",
                table: "Flight");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureAirportId",
                table: "Flight",
                column: "DepartureAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DepartureAirportId",
                table: "Flight",
                column: "DepartureAirportId",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DepartureAirportId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DepartureAirportId",
                table: "Flight");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_Id",
                table: "Flight",
                column: "Id",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
