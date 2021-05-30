using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.DataLayer.Models
{
    public enum PokemonTypes
    {
        Normal = 0,
        Fight = 1,
        Flying = 2,
        Poison = 3,
        Ground = 4,
        Rock = 5,
        Bug = 6,
        Ghost = 7,
        Steel = 8,
        Fire = 9,
        Water = 10,
        Grass = 11,
        Electric = 12,
        Psychic = 13,
        Ice = 14,
        Dragon = 15,
        Dark = 16,
        Fairy = 17,
    }

    public class Pokemon
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }
        
        //[Required]
        public PokemonTypes Type1 { get; set; }
        
        //[DefaultValue(null)]
        public PokemonTypes? Type2 { get; set; }
    }
}
