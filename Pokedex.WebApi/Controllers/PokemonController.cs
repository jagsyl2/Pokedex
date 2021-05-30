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
        /// Creates a Pokemon.
        /// </summary>
        /// <remarks>
        /// If the Pokemon has only one type, you'll enter null for type2. ("type2": null)
        /// 
        /// Pokemon Types:
        /// 
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
