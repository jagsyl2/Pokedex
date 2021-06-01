using Pokedex.DataLayer.Models;
using System;

namespace Pokedex
{
    public interface IIoHelper
    {
        int GetIntFromUser(string message);
        string GetStringFromUser(string message);
        PokemonTypes GetPokemonTypeFromUser(string message);
        void PrintPokemon(Pokemon pokemon);
    }

    public class IoHelper : IIoHelper
    {
        public string GetStringFromUser(string message)
        {
            Console.WriteLine($"{message}");
            return Console.ReadLine();
        }

        public int GetIntFromUser(string message)
        {
            int userChoice;

            while (!int.TryParse(GetStringFromUser(message), out userChoice))
            {
                Console.WriteLine("This is not a number. Try again...");
            }

            return userChoice;
        }

        public PokemonTypes GetPokemonTypeFromUser(string message)
        {
            var correctValues = "";

            foreach (var pokemonType in (PokemonTypes[])Enum.GetValues(typeof(PokemonTypes)))
            {
                correctValues += $"{pokemonType},";
            }

            object result;
            while (!Enum.TryParse(typeof(PokemonTypes), GetStringFromUser($"{message} ({correctValues}):"), out result))
            {
                Console.WriteLine("Not a correct value - use one from the brackets. Try again...");
            }

            return (PokemonTypes)result;
        }

        private string BuildPokemonString(Pokemon pokemon)
        {
            return $"Id: {pokemon.Id}. Name: {pokemon.Name} - Type1: {pokemon.Type1}, Type2: {pokemon.Type2}";
        }

        public void PrintPokemon(Pokemon pokemon)
        {
            Console.WriteLine(BuildPokemonString(pokemon));
        }
    }
}
