using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class AddMayorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mayors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mayors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mayors_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mayors",
                columns: new[] { "Id", "Age", "CityId", "Name" },
                values: new object[] { 1, 32, 1, "Vico Sotto" });

            migrationBuilder.InsertData(
                table: "Mayors",
                columns: new[] { "Id", "Age", "CityId", "Name" },
                values: new object[] { 2, 38, 2, "Abby Binay" });

            migrationBuilder.InsertData(
                table: "Mayors",
                columns: new[] { "Id", "Age", "CityId", "Name" },
                values: new object[] { 3, 45, 3, "Isko Moreno" });

            migrationBuilder.CreateIndex(
                name: "IX_Mayors_CityId",
                table: "Mayors",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mayors");
        }
    }
}
