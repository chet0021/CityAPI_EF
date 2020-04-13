using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class MayorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name", "Nickname" },
                values: new object[] { 1, 45, "Isko Moreno", "Yorme" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name", "Nickname" },
                values: new object[] { 2, 45, "Vicco Sotto", "Vivico" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name", "Nickname" },
                values: new object[] { 3, 44, "Marcy Teodoro", "Marcy" });
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

            migrationBuilder.DeleteData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
