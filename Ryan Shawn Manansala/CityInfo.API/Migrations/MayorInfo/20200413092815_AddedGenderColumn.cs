using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations.MayorInfo
{
    public partial class AddedGenderColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Mayor",
                maxLength: 1,
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
                column: "Gender",
                value: "M");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Mayor");
        }
    }
}
