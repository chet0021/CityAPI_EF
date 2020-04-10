using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
	public partial class InsertSampleDate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "City",
				columns: new[] { "Id", "Description", "Name" },
				values: new object[] { 1, "Business center in the North", "Pasig City" });

			migrationBuilder.InsertData(
				table: "City",
				columns: new[] { "Id", "Description", "Name" },
				values: new object[] { 2, "Shopping capital", "Makati City" });

			migrationBuilder.InsertData(
				table: "City",
				columns: new[] { "Id", "Description", "Name" },
				values: new object[] { 3, "Capital of the Philippines", "Manila" });

			migrationBuilder.InsertData(
				table: "PointsOfInterest",
				columns: new[] { "Id", "CityId", "Description", "Name" },
				values: new object[,]
				{
					{ 1, 1, "central business district located within the joint boundaries of Pasig, Mandaluyong and Quezon City", "Ortigas Center" },
					{ 2, 1, "The Pasig River is a river in the Philippines that connects Laguna de Bay to Manila Bay", "Pasig River" },
					{ 3, 2, "shopping capital of the PH", "Greenbelt" },
					{ 4, 3, "Cheap bargains", "Divisoria" },
					{ 5, 3, "Chinese people", "Binondo" },
					{ 6, 3, "Park of Rizal", "Rizal Park" }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
			   table: "PointsOfInterest",
			   keyColumn: "Id",
			   keyValue: 1);

			migrationBuilder.DeleteData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: 5);

			migrationBuilder.DeleteData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: 6);

			migrationBuilder.DeleteData(
				table: "City",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "City",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "City",
				keyColumn: "Id",
				keyValue: 3);
		}
	}
}
