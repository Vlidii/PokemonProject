using WebApplication1.DTOs.Pokemon;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class OwnedPokemonMapper
    {
        public static OwnedPokemonDTO ToOwnedPokemonDTO(this OwnedPokemon pokemonModel)
        {
            return new OwnedPokemonDTO
            {
                Name = pokemonModel.Name,
                Ability = pokemonModel.Ability,
                Gender = pokemonModel.Gender,
                Nature = pokemonModel.Nature,
                Shiny = pokemonModel.Shiny,
                Level = pokemonModel.Level,
                HP = pokemonModel.HP,
                Attack = pokemonModel.Attack,
                Defense = pokemonModel.Defense,
                SPAttack = pokemonModel.SPAttack,
                SPDefence = pokemonModel.SPDefence,
                Speed = pokemonModel.Speed,
                Pokemon = pokemonModel.Pokemon.ToPokemonInOwnedFromPokemonDTO(),
                TrainerName = pokemonModel.AppUser.UserName,
            };
        }

        public static OwnedPokemon ToOwnedPokemonFromCaptureDTO(this CapturePokemonDTO pokemonDTO, int pokemonId)
        {
            return new OwnedPokemon
            {
                Name = pokemonDTO.Name,
                Ability = pokemonDTO.Ability,
                Gender = pokemonDTO.Gender,
                Nature = pokemonDTO.Nature,
                Shiny = pokemonDTO.Shiny,
                Level = pokemonDTO.Level,
                IVHP = pokemonDTO.IVHP,
                EVHP = pokemonDTO.EVHP,
                EVAttack = pokemonDTO.EVAttack,
                IVAttack = pokemonDTO.IVAttack,
                EVDefense = pokemonDTO.EVDefense,
                IVDefense = pokemonDTO.IVDefense,
                EVSPAttack = pokemonDTO.EVSPAttack,
                IVSPAttack = pokemonDTO.IVSPAttack,
                EVSPDefence = pokemonDTO.EVSPDefence,
                IVSPDefence = pokemonDTO.IVSPDefence,
                EVSpeed = pokemonDTO.EVSpeed,
                IVSpeed = pokemonDTO.IVSpeed,
                PokemonId = pokemonId,
            };
        }
    }
}
