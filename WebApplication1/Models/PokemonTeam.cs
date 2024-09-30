using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("PokemonTeam")]
    public class PokemonTeam
    {
        public int Id { get; set; }
        public string AppUserId {  get; set; }
        public string TeamName { get; set; } = string.Empty;
        public bool FavoriteTeam { get; set; } = false;
        public int OwnedPokemonId1 { get; set; }
        public int OwnedPokemonId2 { get; set; }
        public int OwnedPokemonId3 { get; set; }
        public int OwnedPokemonId4 { get; set; }
        public int OwnedPokemonId5 { get; set; }
        public int OwnedPokemonId6 { get; set; }
        public AppUser AppUser { get; set; }
        public OwnedPokemon OwnedPokemon1 { get; set; }
        public OwnedPokemon OwnedPokemon2 { get; set; }
        public OwnedPokemon OwnedPokemon3 { get; set; }
        public OwnedPokemon OwnedPokemon4 { get; set; }
        public OwnedPokemon OwnedPokemon5 { get; set; }
        public OwnedPokemon OwnedPokemon6 { get; set; }

    }
}
