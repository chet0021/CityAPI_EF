using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class MayorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PointsOfInterest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mayor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NickName = table.Column<string>(maxLength: 20, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Business center in the North", "Pasig City" },
                    { 2, "Shopping capital", "Makati City" },
                    { 3, "Capital of the Philippines", "Manila" }
                });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Gender", "Name", "NickName" },
                values: new object[,]
                {
                    { 1, 45, "M", "Francisco Moreno Domagoso", "Isko" },
                    { 2, 50, "F", "Maria Josefina Tanya Belmonte Alimurung", "Joy" },
                    { 3, 30, "M", "Victor María Regis Nubla Sotto", "Vico" },
                    { 4, 44, "F", "Mar - len Abigail Binay - Campos", "Abby" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "Category", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "central business district located within the joint boundaries of Pasig, Mandaluyong and Quezon City", "Ortigas Center" },
                    { 2, null, 1, "The Pasig River is a river in the Philippines that connects Laguna de Bay to Manila Bay", "Pasig River" },
                    { 3, null, 2, "Greenbelt is a shopping mall located at Ayala Center", "Greenbelt" },
                    { 4, null, 3, "Cheap bargains", "Divisoria" },
                    { 5, null, 3, "Chinese people", "Binondo" },
                    { 6, null, 3, "Park of Rizal", "Rizal Park" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mayor");

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

            migrationBuilder.DropColumn(
                name: "Category",
                table: "PointsOfInterest");
        }
    }
}
