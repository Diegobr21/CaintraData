using Microsoft.EntityFrameworkCore.Migrations;

namespace CaintraData.Migrations
{
    public partial class AddActivoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "UsuariosTable",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "UsuariosTable");
        }
    }
}
