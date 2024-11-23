using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AñadirInventarioIdentidadMVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenCarritoId = table.Column<int>(type: "int", nullable: true),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    ProductoSuministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventarios_OrdenesEnCarrito_OrdenCarritoId",
                        column: x => x.OrdenCarritoId,
                        principalTable: "OrdenesEnCarrito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventarios_ProductoSuministradores_ProductoSuministradorId",
                        column: x => x.ProductoSuministradorId,
                        principalTable: "ProductoSuministradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_OrdenCarritoId",
                table: "Inventarios",
                column: "OrdenCarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ProductoSuministradorId",
                table: "Inventarios",
                column: "ProductoSuministradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventarios");
        }
    }
}
