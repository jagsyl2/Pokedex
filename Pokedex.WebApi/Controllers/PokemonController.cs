using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.BusinessLayer;
using Pokedex.DataLayer.Models;

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
        /// Create a Pokemon.
        /// </summary>
        /// <remarks>
        /// If the Pokemon has only one type, you'll enter 0 for type2. ("type2": 0)
        /// 
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
        /// <response code="400">If the pokemon has incorrectly defined types</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public int PostPokemon([FromBody] Pokemon pokemon)
        {
            var statusCode = _pokemonService.Add(pokemon) ? HttpContext.Response.StatusCode = 200 : HttpContext.Response.StatusCode = 400;
            
            return statusCode;
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
            _pokemonService.Delete(new Pokemon { Id = id });
        }
    }
}
