using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class CreateMayor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MayorId",
                table: "City",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_City_MayorId",
                table: "City",
                column: "MayorId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Mayor_MayorId",
                table: "City",
                column: "MayorId",
                principalTable: "Mayor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Mayor_MayorId",
                table: "City");

            migrationBuilder.DropTable(
                name: "Mayor");

            migrationBuilder.DropIndex(
                name: "IX_City_MayorId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "MayorId",
                table: "City");
        }
    }
}
