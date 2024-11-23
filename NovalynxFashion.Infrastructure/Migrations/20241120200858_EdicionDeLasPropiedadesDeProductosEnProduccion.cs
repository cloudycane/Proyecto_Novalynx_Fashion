using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EdicionDeLasPropiedadesDeProductosEnProduccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDeAbrigosInvernales",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeBotasInvernales",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeCamisetasCasuales",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeCamisetasDeportivas",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeChaquetasInvernales",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDePantalonesDeportivosCasuales",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDePantalonesJeansCasuales",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeSudaderasCasuañes",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeSueteresInvernales",
                table: "ProductosEnVentas");

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "ProductosEnVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Talla",
                table: "ProductosEnVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "Talla",
                table: "ProductosEnVentas");

            migrationBuilder.AddColumn<int>(
                name: "TipoDeAbrigosInvernales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeBotasInvernales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeCamisetasCasuales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeCamisetasDeportivas",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeChaquetasInvernales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDePantalonesDeportivosCasuales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDePantalonesJeansCasuales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeSudaderasCasuañes",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeSueteresInvernales",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);
        }
    }
}
