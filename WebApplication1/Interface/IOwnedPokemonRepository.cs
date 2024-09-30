using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IOwnedPokemonRepository
    {
        Task<List<OwnedPokemon>> GetAllAsync(OwnedPokemonQuery query);
        Task<OwnedPokemon?> GetByIdAsync(int id);
        Task<OwnedPokemon> CreateAsync(OwnedPokemon ownedPokemonModel);
        Task<OwnedPokemon?> UpdateAsync(int id, OwnedPokemon ownedPokemonModel);
        Task<OwnedPokemon?> DeleteAsync(int id);
    }
}
