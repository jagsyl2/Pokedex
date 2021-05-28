using Microsoft.AspNetCore.Mvc;
using Pokedex.BusinessLayer;
using Pokedex.DataLayer.Models;
using System.Collections.Generic;

namespace Pokedex.WebApi.Controllers
{
    [Route("api/pokemons")]
    public class PokemonController : ControllerBase
    {
        private IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public List<Pokemon> GetAll()
        {
            return _pokemonService.GetAll();
        }

        [HttpGet("{id}")]
        public Pokemon GetById(int id)
        {
            return _pokemonService.GetById(id);
        }

        [HttpGet("{type}")]
        public List<Pokemon> GetByType(string type)
        {
            return _pokemonService.GetByType(type);
        }

        [HttpGet("{name}")]
        public Pokemon GetByName(string name)
        {
            return _pokemonService.GetByName(name);
        }

        [HttpPost]
        public void PostPokemon([FromBody] Pokemon pokemon)
        {
            _pokemonService.Add(pokemon);
        }

        [HttpPut("{id}")]
        public void PutPokemon([FromBody] Pokemon pokemon, int id)
        {
            pokemon.Id = id;
            _pokemonService.Update(pokemon);
        }

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
