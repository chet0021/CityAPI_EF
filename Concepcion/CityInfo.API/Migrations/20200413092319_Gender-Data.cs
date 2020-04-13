using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class GenderData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: "M");

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Gender", "Name", "Nickname" },
                values: new object[] { 4, 50, "F", "Joy Belmonte", "No Joy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: null);
        }
    }
}
