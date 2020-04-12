using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
	public partial class AddMayorSampleData : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Mayor",
				columns: new[] { "Id", "Name", "Age" },
				values: new object[] { 1, "Vico Sotto", 30 });

			migrationBuilder.UpdateData(
				table: "City",
				keyColumn: "Id",
				keyValue: 1,
				column: "MayorId",
				value: 1);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
