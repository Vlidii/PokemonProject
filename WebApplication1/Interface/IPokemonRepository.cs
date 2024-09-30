using System.Xml.Linq;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetAllAsync(PokemonQuery query);
        Task<Pokemon?> GetByIdAsync(int id);
        Task<Pokemon> CreateAsync(Pokemon pokemonModel);
        Task<Pokemon?> UpdateAsync(int id, Pokemon pokemonModel);
        Task<Pokemon?> DeleteAsync(int id);
        Task<bool> PokemonExists(int pokemonId);
    }
}
