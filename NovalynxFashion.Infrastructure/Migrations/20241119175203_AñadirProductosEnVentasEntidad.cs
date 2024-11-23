using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AñadirProductosEnVentasEntidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductosEnVentasId",
                table: "ProductoSuministradores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductosEnVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoProducto = table.Column<int>(type: "int", nullable: false),
                    Coste = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosEnVentas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoSuministradores_ProductosEnVentasId",
                table: "ProductoSuministradores",
                column: "ProductosEnVentasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoSuministradores_ProductosEnVentas_ProductosEnVentasId",
                table: "ProductoSuministradores",
                column: "ProductosEnVentasId",
                principalTable: "ProductosEnVentas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoSuministradores_ProductosEnVentas_ProductosEnVentasId",
                table: "ProductoSuministradores");

            migrationBuilder.DropTable(
                name: "ProductosEnVentas");

            migrationBuilder.DropIndex(
                name: "IX_ProductoSuministradores_ProductosEnVentasId",
                table: "ProductoSuministradores");

            migrationBuilder.DropColumn(
                name: "ProductosEnVentasId",
                table: "ProductoSuministradores");
        }
    }
}
