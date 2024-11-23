using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovalynxFashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ÁñadirPropiedadImageProfileParaApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageProfile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageProfile",
                table: "AspNetUsers");
        }
    }
}
