using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EdicionDeLasPropiedadesDeProductosEnProduccion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ProductosEnVentas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonasEnum",
                table: "ProductosEnVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ProductosEnVentas");

            migrationBuilder.DropColumn(
                name: "PersonasEnum",
                table: "ProductosEnVentas");

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
        }
    }
}
