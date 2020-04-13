using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class UpdatedCityToOneToZeroRelationshipToMayor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mayors_CityId",
                table: "Mayors");

            migrationBuilder.CreateIndex(
                name: "IX_Mayors_CityId",
                table: "Mayors",
                column: "CityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mayors_CityId",
                table: "Mayors");

            migrationBuilder.CreateIndex(
                name: "IX_Mayors_CityId",
                table: "Mayors",
                column: "CityId");
        }
    }
}
