using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedidos.Infraestructure.EF.Migrations
{
    public partial class AddedRecipeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Producto",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "esReceta",
                table: "Producto",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "esReceta",
                table: "Producto");
        }
    }
}
