using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoERP.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDeProductoSuministradorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductosSuministradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuministradorId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConIVA = table.Column<bool>(type: "bit", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosSuministradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosSuministradores_Suministradores_SuministradorId",
                        column: x => x.SuministradorId,
                        principalTable: "Suministradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosSuministradores_SuministradorId",
                table: "ProductosSuministradores",
                column: "SuministradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosSuministradores");
        }
    }
}
