using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
	public partial class AddCategoryColumn_PointOfInterest : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Category",
				table: "PointsOfInterest",
				nullable: true);

			migrationBuilder.UpdateData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: "4",
				column: "Category",
				value: "ShoppingCenter"
				);

			migrationBuilder.UpdateData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: "5",
				column: "Category",
				value: "ShoppingCenter"
				);

			migrationBuilder.UpdateData(
				table: "PointsOfInterest",
				keyColumn: "Id",
				keyValue: "6",
				column: "Category",
				value: "Tourism"
				);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Category",
				table: "PointsOfInterest");
		}
	}
}
