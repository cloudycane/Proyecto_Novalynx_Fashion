using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AñadirEntidadVentasArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductosParaLaVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductosEnProduccionModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosParaLaVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosParaLaVenta_ProductosEnVentas_ProductosEnProduccionModelId",
                        column: x => x.ProductosEnProduccionModelId,
                        principalTable: "ProductosEnVentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosParaLaVenta_ProductosEnProduccionModelId",
                table: "ProductosParaLaVenta",
                column: "ProductosEnProduccionModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosParaLaVenta");
        }
    }
}
