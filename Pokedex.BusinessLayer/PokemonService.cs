using Pokedex.DataLayer;
using Pokedex.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pokedex.BusinessLayer
{
    public interface IPokemonService
    {
        void Add(Pokemon pokemon);
        void Delete(Pokemon pokemon);
        List<Pokemon> GetAll();
        Pokemon GetById(int id);
        Pokemon GetByName(string name);
        List<Pokemon> GetByType(string type);
        void Update(Pokemon pokemon);
    }

    public class PokemonService : IPokemonService
    {
        public void Add(Pokemon pokemon)
        {
            using (var context = new PokedexDbContext())
            {
                context.Pokemons.Add(pokemon);
                context.SaveChanges();
            }
        }

        public List<Pokemon> GetAll()
        {
            using (var context = new PokedexDbContext())
            {
                return context.Pokemons.ToList();
            }
        }

        public Pokemon GetById(int id)
        {
            using (var context = new PokedexDbContext())
            {
                return context.Pokemons
                    .FirstOrDefault(pokemon => pokemon.Id == id);
            }
        }

        public List<Pokemon> GetByType(string type)
        {
            using (var context = new PokedexDbContext())
            {
                return context.Pokemons
                    .Where(pokemon => pokemon.Type == type)
                    .ToList();
            }
        }

        public Pokemon GetByName(string name)
        {
            using (var context = new PokedexDbContext())
            {
                return context.Pokemons
                    .FirstOrDefault(pokemon => pokemon.Name == name);
            }
        }

        public void Update(Pokemon pokemon)
        {
            using (var context = new PokedexDbContext())
            {
                context.Pokemons.Update(pokemon);
                context.SaveChanges();
            }
        }

        public void Delete(Pokemon pokemon)
        {
            using (var context = new PokedexDbContext())
            {
                context.Pokemons.Remove(pokemon);
                context.SaveChanges();
            }
        }
    }
}
