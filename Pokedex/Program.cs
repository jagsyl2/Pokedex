using Pokedex.BusinessLayer;
using Pokedex.DataLayer.Models;
using System;
using System.Collections.Generic;
using Unity;

namespace Pokedex
{
    class Program
    {
        private readonly IDatabaseManagementService _databaseManagementService;
        private readonly IIoHelper _ioHelper;
        private readonly IPokemonService _pokemonService;

        private bool _exit = false;

        static void Main(string[] args)
        {
            var container = new UnityDiContainerProvider().GetContainer();

            container.Resolve<Program>().Run();
        }

        public Program(
            IDatabaseManagementService databaseManagementService,
            IIoHelper ioHelper,
            IPokemonService pokemonService)
        {
            _databaseManagementService = databaseManagementService;
            _ioHelper = ioHelper;
            _pokemonService = pokemonService;
        }

        private void Run()
        {
            _databaseManagementService.EnsureDatabaseCreation();

            do
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Add pokemon");
                Console.WriteLine("2. Print all pokemon");
                Console.WriteLine("3. Find pokemon by id");
                Console.WriteLine("4. Find pokemon by name");
                Console.WriteLine("5. Find pokemon by type");
                Console.WriteLine("6. Find pokemon by 2 types");
                Console.WriteLine("7. Update pokemon");
                Console.WriteLine("8. Delete pokemon");
                Console.WriteLine("9. Exit");

                var userChoice = _ioHelper.GetIntFromUser("Select option:");

                switch (userChoice)
                {
                    case 1:
                        AddPokemon();
                        break;
                    case 2:
                        PrintAllPokemon();
                        break;
                    case 3:
                        FindPokemonById();
                        break;
                    case 4:
                        FindPokemonByName();
                        break;
                    case 5:
                        FindPokemonByType();
                        break;
                    case 6:
                        FindPokemonBy2Types();
                        break;
                    case 7:
                        UpdatePokemon();
                        break;
                    case 8:
                        DeletePokemon();
                        break;
                    case 9:
                        _exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong choice. Try again...");
                        break;
                }
            }
            while (!_exit);
        }

        private void DeletePokemon()
        {
            var id = _ioHelper.GetIntFromUser("Provide pokemon id");

            _pokemonService.Delete(new Pokemon { Id = id });
        }

        private void UpdatePokemon()
        {
            var id = _ioHelper.GetIntFromUser("Provide pokemon id");

            var pokemon = _pokemonService.GetById(id);

            pokemon.Name = _ioHelper.GetStringFromUser($"Privde new name [current: {pokemon.Name}]:");
            pokemon.Type1 = _ioHelper.GetPokemonTypeFromUser($"Privde new type [current: {pokemon.Type1}]:");
            pokemon.Type2 = _ioHelper.GetPokemonTypeFromUser($"Privde new type [current: {pokemon.Type2}]:");

            _pokemonService.Update(pokemon);
        }

        private void FindPokemonBy2Types()
        {
            var type1 = _ioHelper.GetPokemonTypeFromUser("Provide pokemon type");
            var type2 = _ioHelper.GetPokemonTypeFromUser("Provide pokemon second type");
            var pokemon = _pokemonService.GetByTypes(type1, type2);

            PrintAllPokemon(pokemon);
        }

        private void FindPokemonByType()
        {
            var type = _ioHelper.GetPokemonTypeFromUser("Provide pokemon type");
            var pokemon = _pokemonService.GetByType(type);

            PrintAllPokemon(pokemon);
        }

        private void FindPokemonByName()
        {
            var name = _ioHelper.GetStringFromUser("Provide pokemon name");
            var pokemon = _pokemonService.GetByName(name);

            PrintAllPokemon(pokemon);
        }

        private void FindPokemonById()
        {
            var id = _ioHelper.GetIntFromUser("Provide pokemon id");
            var pokemon = _pokemonService.GetById(id);

            _ioHelper.PrintPokemon(pokemon);
        }

        private void PrintAllPokemon()
        {
            var pokemon = _pokemonService.GetAll();
            PrintAllPokemon(pokemon);
        }

        private void AddPokemon()
        {
            var newPokemon = new Pokemon
            {
                Name = _ioHelper.GetStringFromUser("Enter pokemon name:"),
                Type1 = _ioHelper.GetPokemonTypeFromUser("Enter first type:"),
                Type2 = _ioHelper.GetPokemonTypeFromUser("Enter second type:"),
            };

            if (_pokemonService.Add(newPokemon))
            {
                Console.WriteLine("Pokemon added successfully");
            }
            else 
            {
                Console.WriteLine("Pokemon has incorrectly defined types. Try again...");
            }
        }

        private void PrintAllPokemon(List<Pokemon> pokemon)
        {
            for (var i = 0; i < pokemon.Count; i++)
            {
                var item = pokemon[i];

                _ioHelper.PrintPokemon(item);
            }
        }
    }
}
