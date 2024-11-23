using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDeProductoSuministradorEntidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductoSuministradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonedaPreferida = table.Column<int>(type: "int", nullable: false),
                    CosteProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    UnidadProducto = table.Column<int>(type: "int", nullable: false),
                    SuministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoSuministradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoSuministradores_Suministradores_SuministradorId",
                        column: x => x.SuministradorId,
                        principalTable: "Suministradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoSuministradores_SuministradorId",
                table: "ProductoSuministradores",
                column: "SuministradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoSuministradores");
        }
    }
}
