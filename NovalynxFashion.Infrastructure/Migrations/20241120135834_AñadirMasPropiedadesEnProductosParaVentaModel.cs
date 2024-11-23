using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AñadirMasPropiedadesEnProductosParaVentaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeCreacion",
                table: "ProductosParaLaVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDeCreacion",
                table: "ProductosParaLaVenta");

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
        }
    }
}
