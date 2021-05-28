using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator1.NET.Migrations
{
    public partial class UpdatePharmacists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pharmacists",
                table: "pharmacists");

            migrationBuilder.RenameTable(
                name: "pharmacists",
                newName: "Pharmacists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacists",
                table: "Pharmacists",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacists",
                table: "Pharmacists");

            migrationBuilder.RenameTable(
                name: "Pharmacists",
                newName: "pharmacists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pharmacists",
                table: "pharmacists",
                column: "id");
        }
    }
}
