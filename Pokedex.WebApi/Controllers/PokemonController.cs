using Microsoft.AspNetCore.Mvc;
using Pokedex.BusinessLayer;
using Pokedex.DataLayer.Models;
using System.Collections.Generic;

namespace Pokedex.WebApi.Controllers
{
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Gets all Pokemon.
        /// </summary>
        [HttpGet]
        public List<Pokemon> GetAll()
        {
            return _pokemonService.GetAll();
        }

        /// <summary>
        /// Gets a specific Pokemon.
        /// </summary>
        /// <param name="id">Enter the Pokemon ID</param>
        [HttpGet("{id}")]
        public Pokemon GetById(int id)
        {
            return _pokemonService.GetById(id);
        }

        /// <summary>
        /// Gets pokemon of a given type.
        /// </summary>
        /// <param name="type">
        /// Pokemon Types:
        ///     Normal = 0,
        ///     Fight = 1,
        ///     Flying = 2,
        ///     Poison = 3,
        ///     Ground = 4,
        ///     Rock = 5,
        ///     Bug = 6,
        ///     Ghost = 7,
        ///     Steel = 8,
        ///     Fire = 9,
        ///     Water = 10,
        ///     Grass = 11,
        ///     Electric = 12,
        ///     Psychic = 13,
        ///     Ice = 14,
        ///     Dragon = 15,
        ///     Dark = 16,
        ///     Fairy = 17.
        /// </param>
        [HttpGet("type")]
        public List<Pokemon> GetByType(PokemonTypes type)
        {
            return _pokemonService.GetByType(type);
        }

        /// <summary>
        /// Gets pokemon of a given two types.
        /// </summary>
        /// <remarks>
        /// Pokemon Types:
        ///     Normal = 0,
        ///     Fight = 1,
        ///     Flying = 2,
        ///     Poison = 3,
        ///     Ground = 4,
        ///     Rock = 5,
        ///     Bug = 6,
        ///     Ghost = 7,
        ///     Steel = 8,
        ///     Fire = 9,
        ///     Water = 10,
        ///     Grass = 11,
        ///     Electric = 12,
        ///     Psychic = 13,
        ///     Ice = 14,
        ///     Dragon = 15,
        ///     Dark = 16,
        ///     Fairy = 17.
        /// </remarks>
        /// <param name="type1">Choose the first type</param>
        /// <param name="type2">Choose the second type</param>
        [HttpGet("types")]
        public List<Pokemon> GetByTypes(PokemonTypes type1, PokemonTypes type2)
        {
            return _pokemonService.GetByTypes(type1, type2);
        }

        /// <summary>
        /// Gets pokemon by name.
        /// </summary>
        /// <param name="name">Enter the Pokemon name</param>
        [HttpGet("name")]
        public Pokemon GetByName(string name)
        {
            return _pokemonService.GetByName(name);
        }

        /// <summary>
        /// Creates a Pokemon.
        /// </summary>
        /// <remarks>
        /// If the Pokemon has only one type, you'll enter null for type2. ("type2": null)
        /// 
        /// Pokemon Types:
        ///     Normal = 0,
        ///     Fight = 1,
        ///     Flying = 2,
        ///     Poison = 3,
        ///     Ground = 4,
        ///     Rock = 5,
        ///     Bug = 6,
        ///     Ghost = 7,
        ///     Steel = 8,
        ///     Fire = 9,
        ///     Water = 10,
        ///     Grass = 11,
        ///     Electric = 12,
        ///     Psychic = 13,
        ///     Ice = 14,
        ///     Dragon = 15,
        ///     Dark = 16,
        ///     Fairy = 17.
        /// </remarks>
        [HttpPost]
        public void PostPokemon([FromBody] Pokemon pokemon)
        {
            _pokemonService.Add(pokemon);
        }

        /// <summary>
        /// Update the Pokemon.
        /// </summary>
        /// <param name="id">Enter the Pokemon ID</param>
        [HttpPut("{id}")]
        public void PutPokemon([FromBody] Pokemon pokemon, int id)
        {
            pokemon.Id = id;
            _pokemonService.Update(pokemon);
        }

        /// <summary>
        /// Delete the Pokemon.
        /// </summary>
        /// <param name="id">Enter the Pokemon ID</param>
        [HttpDelete("{id}")]
        public void DeletePokemon(int id)
        {
            _pokemonService.Delete(new Pokemon 
            {
                Id = id,
            });
        }
    }
}
