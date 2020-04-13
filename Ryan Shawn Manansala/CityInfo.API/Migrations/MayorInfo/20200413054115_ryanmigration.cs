using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations.MayorInfo
{
    public partial class ryanmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mayor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 45, "Isko Moreno" });

            migrationBuilder.InsertData(
                table: "Mayor",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 42, "Francis Zamora" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mayor");
        }
    }
}
