using Pokedex.DataLayer;
using Pokedex.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokedex.BusinessLayer
{
    public interface IPokemonService
    {
        bool Add(Pokemon pokemon);
        void Delete(Pokemon pokemon);
        List<Pokemon> GetAll();
        Pokemon GetById(int id);
        List<Pokemon> GetByName(string name);
        List<Pokemon> GetByType(PokemonTypes type);
        List<Pokemon> GetByTypes(PokemonTypes type1, PokemonTypes type2);
        void Update(Pokemon pokemon);
    }

    public class PokemonService : IPokemonService
    {
        private readonly Func<IPokedexDbContext> _dbContextFactoryMethod;

        public PokemonService(Func<IPokedexDbContext> dbContextFactoryMethod)
        {
            _dbContextFactoryMethod = dbContextFactoryMethod;
        }

        public bool Add(Pokemon pokemon)
        {
            if (pokemon.Type1 != 0 && pokemon.Type1 != pokemon.Type2)
            {
                using (var context = _dbContextFactoryMethod())
                {
                    context.Pokemons.Add(pokemon);
                    context.SaveChanges();
                }

                return true;
            }

            return false;
        }

        public List<Pokemon> GetAll()
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Pokemons.ToList();
            }
        }

        public Pokemon GetById(int id)
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Pokemons
                    .FirstOrDefault(pokemon => pokemon.Id == id);
            }
        }

        public List<Pokemon> GetByType(PokemonTypes type)
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Pokemons
                    .Where(pokemon => pokemon.Type1 == type || pokemon.Type2 == type)
                    .ToList();
            }
        }

        public List<Pokemon> GetByTypes(PokemonTypes type1, PokemonTypes type2)
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Pokemons
                    .Where(pokemon => (pokemon.Type1 ==type1 || pokemon.Type2 == type1) && (pokemon.Type1 == type2 || pokemon.Type2 == type2))
                    .ToList();
            }
        }

        public List<Pokemon> GetByName(string name)
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Pokemons
                    .Where(pokemon => pokemon.Name == name)
                    .ToList();
            }
        }

        public void Update(Pokemon pokemon)
        {
            using (var context = _dbContextFactoryMethod())
            {
                context.Pokemons.Update(pokemon);
                context.SaveChanges();
            }
        }

        public void Delete(Pokemon pokemon)
        {
            using (var context = _dbContextFactoryMethod())
            {
                context.Pokemons.Remove(pokemon);
                context.SaveChanges();
            }
        }
    }
}
