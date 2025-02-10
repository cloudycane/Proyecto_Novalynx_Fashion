using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoERP.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDeSuministradorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suministradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionLinea1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionLinea2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeRegistracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suministradores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suministradores");
        }
    }
}
