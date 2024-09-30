using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interface;
using WebApplication1.Models;
using WebApplication1.Helpers;
using WebApplication1.Helpers;

namespace WebApplication1.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDBContext _context;
        public PokemonRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Pokemon> CreateAsync(Pokemon pokemonModel)
        {
            await _context.Pokemons.AddAsync(pokemonModel);
            await _context.SaveChangesAsync();
            return pokemonModel;
        }

        public async Task<Pokemon?> DeleteAsync(int id)
        {
            var pokemonModel = await _context.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
            if (pokemonModel == null) 
            {
                return null;
            }
            _context.Pokemons.Remove(pokemonModel);
            await _context.SaveChangesAsync();
            return pokemonModel;
        }

        public async Task<List<Pokemon>> GetAllAsync(PokemonQuery query)
        {
            var pokemons = _context.Pokemons.Include(op => op.OwnedPokemons).ThenInclude(a => a.AppUser).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(query.PokemonName))
            {
                pokemons = pokemons.Where(x => x.PokemonName.Contains(query.PokemonName));
            }

            if (!string.IsNullOrWhiteSpace(query.PokemonType1) && !string.IsNullOrWhiteSpace(query.PokemonType2))
            {
                pokemons = pokemons.Where(x => ((x.PokemonType.Equals(query.PokemonType1) || x.PokemonType.Equals(query.PokemonType2)) && ((x.PokemonType2.Equals(query.PokemonType1) || x.PokemonType2.Equals(query.PokemonType2)))));
            }
            else if (!string.IsNullOrWhiteSpace(query.PokemonType1))
            {
                pokemons = pokemons.Where(x => x.PokemonType.Equals(query.PokemonType1) || x.PokemonType2.Equals(query.PokemonType1));
            }

            if (string.IsNullOrWhiteSpace(query.SortBy) || query.SortBy == "PokemonNumber")
            {
                pokemons = query.IsDecsending ? pokemons.OrderByDescending(p => p.PokemonNumber) : pokemons.OrderBy(p => p.PokemonNumber);
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy == "HP")
                {
                    pokemons = query.IsDecsending ? pokemons.OrderByDescending(p => p.BaseHP) : pokemons.OrderBy(p => p.BaseHP);
                }
                else if (query.SortBy == "Attack")
                {
                    pokemons = query.IsDecsending ? pokemons.OrderByDescending(p => p.BaseAttack) : pokemons.OrderBy(p => p.BaseAttack);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await pokemons.Skip(skipNumber).Take(query.PageSize).ToListAsync();
               
        }

        public async Task<Pokemon?> GetByIdAsync(int id)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Pokemon?> UpdateAsync(int id, Pokemon pokemonModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PokemonExists(int pokemonId)
        {
            return _context.Pokemons.AnyAsync(p => p.Id == pokemonId);
        }
    }
}
