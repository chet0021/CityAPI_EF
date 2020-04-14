using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class AddedGenderColumn_MayorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Mayor",
                nullable: true);

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
                columns: new[] { "Age", "Gender" },
                values: new object[] { 40, "M" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Gender", "Name" },
                values: new object[] { 3, 50, "F", "Mayor Joy Belmonte" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Mayor");

            migrationBuilder.UpdateData(
                table: "Mayor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 30);
        }
    }
}
