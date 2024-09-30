using System.Xml.Linq;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IPokemonTeamRepository
    {
        Task<List<PokemonTeam>> GetAllAsync();
        Task<PokemonTeam?> GetByIdAsync(int id);
        Task<List<PokemonTeam>> GetByUserIdAsync(string id);
        Task<PokemonTeam> CreateAsync(PokemonTeam pokemonTeamModel);
        Task<PokemonTeam?> AddToPokemonTeamAsync(int id, int teamSlot, PokemonTeam pokemonTeam);
        Task<PokemonTeam?> DeleteAsync(int id);
    }
}
