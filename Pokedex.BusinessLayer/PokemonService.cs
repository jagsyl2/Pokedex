using Pokedex.DataLayer;
using Pokedex.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pokedex.BusinessLayer
{
    public class PokemonService
    {
        public void Add(Pokemon pokemon)
        {
            using(var context = new PokedexDbContext())
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
