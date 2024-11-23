using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionDePruebaSiProductoEnVentasyProductoSuministradorCoinciden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoSuministradores_ProductosEnVentas_ProductosEnVentasId",
                table: "ProductoSuministradores");

            migrationBuilder.DropIndex(
                name: "IX_ProductoSuministradores_ProductosEnVentasId",
                table: "ProductoSuministradores");

            migrationBuilder.DropColumn(
                name: "ProductosEnVentasId",
                table: "ProductoSuministradores");

            migrationBuilder.CreateTable(
                name: "ProductosEnVentasIngredientes",
                columns: table => new
                {
                    IngredientesId = table.Column<int>(type: "int", nullable: false),
                    ProductosEnVentasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosEnVentasIngredientes", x => new { x.IngredientesId, x.ProductosEnVentasId });
                    table.ForeignKey(
                        name: "FK_ProductosEnVentasIngredientes_ProductoSuministradores_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "ProductoSuministradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosEnVentasIngredientes_ProductosEnVentas_ProductosEnVentasId",
                        column: x => x.ProductosEnVentasId,
                        principalTable: "ProductosEnVentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEnVentasIngredientes_ProductosEnVentasId",
                table: "ProductosEnVentasIngredientes",
                column: "ProductosEnVentasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosEnVentasIngredientes");

            migrationBuilder.AddColumn<int>(
                name: "ProductosEnVentasId",
                table: "ProductoSuministradores",
                type: "int",
                nullable: true);

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
    }
}
