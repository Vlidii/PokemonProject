using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Helpers;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class OwnedPokemonRepository : IOwnedPokemonRepository
    {
        private readonly ApplicationDBContext _context;
        public OwnedPokemonRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<OwnedPokemon> CreateAsync(OwnedPokemon ownedPokemonModel)
        {
            var counter = new Counters();
            ownedPokemonModel.HP = counter.CountHP(ownedPokemonModel.Pokemon.BaseHP,ownedPokemonModel.IVHP,ownedPokemonModel.EVHP, ownedPokemonModel.Level);
            ownedPokemonModel.Attack = counter.CountStat(ownedPokemonModel.Pokemon.BaseAttack,ownedPokemonModel.IVAttack,ownedPokemonModel.EVAttack,ownedPokemonModel.Level);
            ownedPokemonModel.Defense = counter.CountStat(ownedPokemonModel.Pokemon.BaseDefense, ownedPokemonModel.IVDefense, ownedPokemonModel.EVDefense, ownedPokemonModel.Level);
            ownedPokemonModel.SPAttack = counter.CountStat(ownedPokemonModel.Pokemon.BaseSPAttack, ownedPokemonModel.IVSPAttack, ownedPokemonModel.EVSPAttack, ownedPokemonModel.Level);
            ownedPokemonModel.SPDefence = counter.CountStat(ownedPokemonModel.Pokemon.BaseSPDefense, ownedPokemonModel.IVSPDefence, ownedPokemonModel.EVSPDefence, ownedPokemonModel.Level);
            ownedPokemonModel.Speed = counter.CountStat(ownedPokemonModel.Pokemon.BaseSpeed, ownedPokemonModel.IVSpeed, ownedPokemonModel.EVSpeed, ownedPokemonModel.Level);
            
            if(counter.CheckEV(ownedPokemonModel.EVHP, ownedPokemonModel.EVAttack, ownedPokemonModel.EVDefense, ownedPokemonModel.EVSPAttack, ownedPokemonModel.EVSPDefence, ownedPokemonModel.EVSpeed) == false) 
            {
                return null;                
            }
            await _context.OwnedPokemons.AddAsync(ownedPokemonModel);
            await _context.SaveChangesAsync();
            return ownedPokemonModel;
        }

        public async Task<OwnedPokemon?> DeleteAsync(int id)
        {
            var pokemonModel = await _context.OwnedPokemons.FirstOrDefaultAsync(x => x.Id == id);
            if (pokemonModel == null)
            {
                return null;
            }
            _context.OwnedPokemons.Remove(pokemonModel);
            await _context.SaveChangesAsync();
            return pokemonModel;
        }

        public async Task<List<OwnedPokemon>> GetAllAsync(OwnedPokemonQuery query)
        {
            var pokemons = _context.OwnedPokemons.Include(u => u.AppUser).Include(p => p.Pokemon).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.PokemonName))
            {
                pokemons = pokemons.Where(x => x.Pokemon.PokemonName.Contains(query.PokemonName));
            }

            if (!string.IsNullOrWhiteSpace(query.PokemonType1) && !string.IsNullOrWhiteSpace(query.PokemonType2))
            {
                pokemons = pokemons.Where(x => ((x.Pokemon.PokemonType.Equals(query.PokemonType1) || x.Pokemon.PokemonName.Equals(query.PokemonType2)) && ((x.Pokemon.PokemonType2.Equals(query.PokemonType1) || x.Pokemon.PokemonType2.Equals(query.PokemonType2)))));
            }
            else if (!string.IsNullOrWhiteSpace(query.PokemonType1))
            {
                pokemons = pokemons.Where(x => x.Pokemon.PokemonName.Equals(query.PokemonType1) || x.Pokemon.PokemonName.Equals(query.PokemonType1));
            }

            if (string.IsNullOrWhiteSpace(query.SortBy) || query.SortBy == "PokemonNumber")
            {
                pokemons = query.IsDecsending ? pokemons.OrderByDescending(p => p.Pokemon.PokemonName) : pokemons.OrderBy(p => p.Pokemon.PokemonName);
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy == "HP")
                {
                    pokemons = query.IsDecsending ? pokemons.OrderByDescending(p => p.HP) : pokemons.OrderBy(p => p.HP);
                }
                else if (query.SortBy == "Attack")
                {
                    pokemons = query.IsDecsending ? pokemons.OrderByDescending(p => p.Attack) : pokemons.OrderBy(p => p.Attack);
                }
                //Add other stats
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await pokemons.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<OwnedPokemon?> GetByIdAsync(int id)
        {
            return await _context.OwnedPokemons.Include(a => a.AppUser).Include(p => p.Pokemon).FirstOrDefaultAsync(op => op.Id == id);
        }

        public Task<OwnedPokemon?> UpdateAsync(int id, OwnedPokemon ownedPokemonModel)
        {
            throw new NotImplementedException();
        }
    }
}
