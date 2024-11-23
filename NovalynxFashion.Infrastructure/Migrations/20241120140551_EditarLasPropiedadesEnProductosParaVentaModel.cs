using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditarLasPropiedadesEnProductosParaVentaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RopaCasual",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "RopaDeInvierno",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "RopaDeOficina",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "RopaDeVerano",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "RopaDeportiva",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "RopaFormal",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "RopaInterior",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeAbrigosInvernales",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeBotasInvernales",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeCamisetasCasuales",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeCamisetasDeportivas",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeChaquetasInvernales",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDePantalonesDeportivosCasuales",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDePantalonesJeansCasuales",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeProductoEnVentas",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeSudaderasCasuañes",
                table: "ProductosParaLaVenta");

            migrationBuilder.DropColumn(
                name: "TipoDeSueteresInvernales",
                table: "ProductosParaLaVenta");

            migrationBuilder.AddColumn<int>(
                name: "RopaCasual",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeInvierno",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeOficina",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeVerano",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeportiva",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaFormal",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaInterior",
                table: "ProductosEnVentas",
                type: "int",
                nullable: true);

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
                name: "TipoDeProductoEnVentas",
                table: "ProductosEnVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RopaCasual",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "RopaDeInvierno",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "RopaDeOficina",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "RopaDeVerano",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "RopaDeportiva",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "RopaFormal",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "RopaInterior",
                table: "ProductosEnVentas");

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
                name: "TipoDeProductoEnVentas",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeSudaderasCasuañes",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "TipoDeSueteresInvernales",
                table: "ProductosEnVentas");

            migrationBuilder.AddColumn<int>(
                name: "RopaCasual",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeInvierno",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeOficina",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeVerano",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaDeportiva",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaFormal",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RopaInterior",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeAbrigosInvernales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeBotasInvernales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeCamisetasCasuales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeCamisetasDeportivas",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeChaquetasInvernales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDePantalonesDeportivosCasuales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDePantalonesJeansCasuales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeProductoEnVentas",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeSudaderasCasuañes",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDeSueteresInvernales",
                table: "ProductosParaLaVenta",
                type: "int",
                nullable: true);
        }
    }
}
