# Pokedex
Simple application that provides endpoints to manage pokemons

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Examples of use](#examples-of-use)

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


## Examples of use for Postman
To create a Pokemon: http://localhost:10500/api/pokemon 
Sample request:
JSON
{
       "id": 0,
       "name": "Bulbasaur",
       "type1": 12,
       "type2": 4
}
If you get code 400 it may mean that the pokemon has incorrectly defined types


To update the Pokemon: http://localhost:10500/api/pokemon/id
Sample request:
JSON
{
       "id": 0,
       "name": "Bulbasaur",
       "type1": 12,
       "type2": 4
}


To delete the Pokemon: http://localhost:10500/api/pokemon/id


## Code Examples
To get all Pokemon: http://localhost:10500/api/search

To get Pokemon by id: http://localhost:10500/api/search/id

To get Pokemon by type: http://localhost:10500/api/search/type?type=id

To get Pokemon by two types: http://localhost:10500/api/search/types?type=id&kind=id

To get Pokemon by name: http://localhost:10500/api/search/name?name={name}
