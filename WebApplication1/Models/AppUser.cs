using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AppUser: IdentityUser
    { 
        public List<OwnedPokemon> OwnedPokemons { get; set; } = new List<OwnedPokemon>();
        public List<PokemonTeam> PokemonTeams { get; set; } = new List<PokemonTeam>();
    }
}
