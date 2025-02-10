using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoERP.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class AñadirPropiedadColorEnCuentaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cuentas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cuentas");
        }
    }
}
