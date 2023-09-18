using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sab_dx_case.Migrations
{
    public partial class changedUrunler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urun",
                table: "Urun");

            migrationBuilder.RenameTable(
                name: "Urun",
                newName: "Urunler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urunler",
                table: "Urunler",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urunler",
                table: "Urunler");

            migrationBuilder.RenameTable(
                name: "Urunler",
                newName: "Urun");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urun",
                table: "Urun",
                column: "Id");
        }
    }
}
