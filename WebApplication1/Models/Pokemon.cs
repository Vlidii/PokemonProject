using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Pokemon")]
    public class Pokemon
    {
        public int Id { get; set; }
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; } = string.Empty;
        public string PokemonInfo { get; set; } = string.Empty;
        public string PokemonType { get; set; } = string.Empty;
        public string PokemonType2 { get; set; } = string.Empty;
        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSPAttack { get; set; }
        public int BaseSPDefense { get; set; }
        public int BaseSpeed { get; set; }

        public List<OwnedPokemon> OwnedPokemons { get; set; } = new List<OwnedPokemon>(); 
    }
}
