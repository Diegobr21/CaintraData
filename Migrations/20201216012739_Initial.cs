using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaintraData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(nullable: true),
                    NombreComercial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Municipio_Estado = table.Column<string>(nullable: true),
                    SitioWeb = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    NumSocio = table.Column<string>(nullable: true),
                    Empresa_Size = table.Column<string>(nullable: true),
                    MembresiaVigente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Municipio_Estado = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    LastUpdate_Phone = table.Column<DateTime>(nullable: false),
                    LastUpdate_Mail = table.Column<DateTime>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true),
                    Whatsapp = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosTable_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosTable_EmpresaId",
                table: "UsuariosTable",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosTable");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
