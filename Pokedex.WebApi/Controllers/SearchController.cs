using Microsoft.AspNetCore.Mvc;
using Pokedex.BusinessLayer;
using Pokedex.DataLayer.Models;
using System.Collections.Generic;

namespace Pokedex.WebApi.Controllers
{
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private IPokemonService _pokemonService;

        public SearchController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Get all Pokemon.
        /// </summary>
        [HttpGet]
        public List<Pokemon> GetAll()
        {
            return _pokemonService.GetAll();
        }

        /// <summary>
        /// Get a specific Pokemon.
        /// </summary>
        /// <param name="id">Enter the Pokemon ID</param>
        [HttpGet("{id}")]
        public Pokemon GetById(int id)
        {
            return _pokemonService.GetById(id);
        }

        /// <summary>
        /// Get pokemon of a given type.
        /// </summary>
        /// <param name="type">
        /// Pokemon Types:
        /// 
        ///    None = 0,
        ///    Normal = 1,
        ///    Fight = 2,
        ///    Flying = 3,
        ///    Poison = 4,
        ///    Ground = 5,
        ///    Rock = 6,
        ///    Bug = 7,
        ///    Ghost = 8,
        ///    Steel = 9,
        ///    Fire = 10,
        ///    Water = 11,
        ///    Grass = 12,
        ///    Electric = 13,
        ///    Psychic = 14,
        ///    Ice = 15,
        ///    Dragon = 16,
        ///    Dark = 17,
        ///    Fairy = 18.
        /// </param>
        [HttpGet("type")]
        public List<Pokemon> GetByType([FromQuery] PokemonTypes type)
        {
            return _pokemonService.GetByType(type);
        }

        /// <summary>
        /// Get pokemon of a given two types.
        /// </summary>
        /// <remarks>
        /// Pokemon Types:
        /// 
        ///    None = 0,
        ///    Normal = 1,
        ///    Fight = 2,
        ///    Flying = 3,
        ///    Poison = 4,
        ///    Ground = 5,
        ///    Rock = 6,
        ///    Bug = 7,
        ///    Ghost = 8,
        ///    Steel = 9,
        ///    Fire = 10,
        ///    Water = 11,
        ///    Grass = 12,
        ///    Electric = 13,
        ///    Psychic = 14,
        ///    Ice = 15,
        ///    Dragon = 16,
        ///    Dark = 17,
        ///    Fairy = 18.
        /// </remarks>
        /// <param name="type1">Choose the first type</param>
        /// <param name="type2">Choose the second type</param>
        [HttpGet("types")]
        public List<Pokemon> GetByTypes([FromQuery] PokemonTypes type1, [FromQuery] PokemonTypes type2)
        {
            return _pokemonService.GetByTypes(type1, type2);
        }

        /// <summary>
        /// Get pokemon by name.
        /// </summary>
        /// <param name="name">Enter the Pokemon name</param>
        [HttpGet("name")]
        public List<Pokemon> GetByName([FromQuery] string name)
        {
            return _pokemonService.GetByName(name);
        }
    }
}
