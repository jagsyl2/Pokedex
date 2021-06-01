# Pokedex
Simple application that provides endpoints to manage pokemons

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Pokemon Types](#pokemon-types)
* [Examples of use for Postman](#examples-of-use-for-postman)
* [Code example](#code-example)

## General info
The Pokedex app contains the WebApi layer for communication via HTTP and it's extended with Swagger.
There're 3 controllers created. The first, StatusController allows to check if the application works correctly. The second, PokemonController includes endpoints that allow to add Pokemon to the database, update them and delete the Pokemon. The last controller, SearchController enables to view all the Pokemon saved in the database or search through filters (i.e. by name).

## Technologies
Project is created with:
* EntityFrameworkCore
* AspNetCore
* Swagger
* Unity

## Setup
To run this project, install it locally and run Pokedex.WebApi. Check if the app is working properly: http://localhost:10500/api/status


## Pokemon Types
If the Pokemon has only one type, you'll enter 0 for type2. ("type2": 0)
 
Pokemon Types:
 
	None = 0,
	Normal = 1,
	Fight = 2,
	Flying = 3,
	Poison = 4,
	Ground = 5,
	Rock = 6,
	Bug = 7,
	Ghost = 8,
	Steel = 9,
	Fire = 10,
	Water = 11,
	Grass = 12,
	Electric = 13,
	Psychic = 14,
	Ice = 15,
	Dragon = 16,
	Dark = 17,
	Fairy = 18.


## Examples of use for Postman
To create a Pokemon: POST http://localhost:10500/api/pokemon 

Sample request:
JSON
{
       "name": "Bulbasaur",
       "type1": 12,
       "type2": 4
}

If you get code 400 it may mean that the pokemon has incorrectly defined types


To update the Pokemon: PUT http://localhost:10500/api/pokemon/id

Sample request:
JSON
{
       "name": "Bulbasaur",
       "type1": 12,
       "type2": 4
}


To delete the Pokemon: DELETE http://localhost:10500/api/pokemon/id


## Code Examples
To get all Pokemon: http://localhost:10500/api/search

To get Pokemon by id: http://localhost:10500/api/search/id

To get Pokemon by type: http://localhost:10500/api/search/type?type=id

To get Pokemon by two types: http://localhost:10500/api/search/types?type1=id&type2=id

To get Pokemon by name: http://localhost:10500/api/search/name?name={name}
