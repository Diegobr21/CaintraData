using Microsoft.EntityFrameworkCore.Migrations;

namespace CaintraData.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "UsuariosTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "EmpresasTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origen",
                table: "UsuariosTable");

            migrationBuilder.DropColumn(
                name: "Origen",
                table: "EmpresasTable");
        }
    }
}
