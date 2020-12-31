using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCTask.Data.Migrations
{
    public partial class fixedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_CityId",
                table: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityId",
                table: "Location",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_CityId",
                table: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityId",
                table: "Location",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
