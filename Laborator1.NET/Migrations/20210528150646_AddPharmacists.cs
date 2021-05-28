using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator1.NET.Migrations
{
    public partial class AddPharmacists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pharmacists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<float>(type: "real", nullable: false),
                    employed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pharmacists", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pharmacists");
        }
    }
}
