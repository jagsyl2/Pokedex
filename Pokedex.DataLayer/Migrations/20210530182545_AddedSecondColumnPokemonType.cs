using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.DataLayer.Migrations
{
    public partial class AddedSecondColumnPokemonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "Type1",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type2",
                table: "Pokemons",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type1",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Type2",
                table: "Pokemons");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
