using Microsoft.EntityFrameworkCore;
using Pokedex.DataLayer.Models;

namespace Pokedex.DataLayer
{
    public class PokedexDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=PokedexDB;Trusted_Connection=True;");
        }
    }
}
