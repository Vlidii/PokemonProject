using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PokemonTeamRepository : IPokemonTeamRepository
    {
        private readonly ApplicationDBContext _context;
        public PokemonTeamRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<PokemonTeam?> AddToPokemonTeamAsync(int id, int teamSlot, PokemonTeam pokemonTeam)
        {
            var existingPokemonTeam = await _context.PokemonTeams.FindAsync(id);

            if (existingPokemonTeam == null) 
            {
                return null;
            }

            if (teamSlot == 1)
            {
                existingPokemonTeam.OwnedPokemon1 = pokemonTeam.OwnedPokemon1;
            }
            else if (teamSlot == 2)
            {
                existingPokemonTeam.OwnedPokemon1 = pokemonTeam.OwnedPokemon1;
            }
            else if (teamSlot == 3)
            {
                existingPokemonTeam.OwnedPokemon3 = pokemonTeam.OwnedPokemon3;
            }
            else if (teamSlot == 4)
            {
                existingPokemonTeam.OwnedPokemon4 = pokemonTeam.OwnedPokemon4;
            }
            else if (teamSlot == 5)
            {
                existingPokemonTeam.OwnedPokemon5 = pokemonTeam.OwnedPokemon5;
            }
            else if (teamSlot == 6)
            {
                existingPokemonTeam.OwnedPokemon6 = pokemonTeam.OwnedPokemon6;
            }

            await _context.SaveChangesAsync();

            return existingPokemonTeam;

        }

        public async Task<PokemonTeam> CreateAsync(PokemonTeam pokemonTeamModel)
        {
            await _context.PokemonTeams.AddAsync(pokemonTeamModel);
            await _context.SaveChangesAsync();
            return pokemonTeamModel;
        }

        public async Task<PokemonTeam?> DeleteAsync(int id)
        {
            var pokemonTeamModel = await _context.PokemonTeams.FirstOrDefaultAsync(x => x.Id == id);
            if (pokemonTeamModel == null)
            {
                return null;
            }
            _context.PokemonTeams.Remove(pokemonTeamModel);
            await _context.SaveChangesAsync();
            return pokemonTeamModel;
        }

        public async Task<List<PokemonTeam>> GetAllAsync()
        {
            return await _context.PokemonTeams.ToListAsync();
        }

        public async Task<PokemonTeam?> GetByIdAsync(int id)
        {
            return await _context.PokemonTeams.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PokemonTeam>> GetByUserIdAsync(string id)
        {
            return await _context.PokemonTeams.Where(p => p.AppUserId == id).ToListAsync();
        }
    }
}
