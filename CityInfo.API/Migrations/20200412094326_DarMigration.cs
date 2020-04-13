using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class DarMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PointsOfInterest_Cities_CityId",
            //    table: "PointsOfInterest");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Cities",
            //    table: "Cities");

            //migrationBuilder.RenameTable(
            //    name: "Cities",
            //    newName: "City");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_City",
            //    table: "City",
            //    column: "Id");

            migrationBuilder.CreateTable(
                name: "Mayor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 42, "John Doe" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 47, "Ervin Night" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 3, 53, "Charles Cruz" });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PointsOfInterest_City_CityId",
            //    table: "PointsOfInterest",
            //    column: "CityId",
            //    principalTable: "City",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PointsOfInterest_City_CityId",
            //    table: "PointsOfInterest");

            migrationBuilder.DropTable(
                name: "Mayor");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_City",
            //    table: "City");

            //migrationBuilder.RenameTable(
            //    name: "City",
            //    newName: "Cities");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Cities",
            //    table: "Cities",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PointsOfInterest_Cities_CityId",
            //    table: "PointsOfInterest",
            //    column: "CityId",
            //    principalTable: "Cities",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
