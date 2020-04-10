using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class MayorDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 45, "Mayor Isko Moreno" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 30, "Mayor Vico Sotto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
