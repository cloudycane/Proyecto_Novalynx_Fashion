using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenovarLaEntidadOrdenCarritoModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenesEnCarrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoSuministradorId = table.Column<int>(type: "int", nullable: false),
                    Aprobacion = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesEnCarrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesEnCarrito_ProductoSuministradores_ProductoSuministradorId",
                        column: x => x.ProductoSuministradorId,
                        principalTable: "ProductoSuministradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesEnCarrito_ProductoSuministradorId",
                table: "OrdenesEnCarrito",
                column: "ProductoSuministradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesEnCarrito");
        }
    }
}
