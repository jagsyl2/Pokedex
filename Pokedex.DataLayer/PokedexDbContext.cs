using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pokedex.DataLayer.Models;
using System;

namespace Pokedex.DataLayer
{
    public interface IPokedexDbContext : IDisposable
    {
        DbSet<Pokemon> Pokemons { get; set; }
        DatabaseFacade Database { get; }
        int SaveChanges();
    }

    public class PokedexDbContext : DbContext, IPokedexDbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=PokedexDB;Trusted_Connection=True;");
        }
    }
}
