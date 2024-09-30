using WebApplication1.DTOs.Pokemon;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class PokemonMapper
    {
        public static PokemonDTO ToPokemonDTO(this Pokemon pokemonModel)
        {
            return new PokemonDTO
            {
                Id = pokemonModel.Id,
                PokemonNumber = pokemonModel.PokemonNumber,
                PokemonName = pokemonModel.PokemonName,
                PokemonInfo = pokemonModel.PokemonInfo,
                PokemonType = pokemonModel.PokemonType,
                PokemonType2 = pokemonModel.PokemonType2,
                BaseHP = pokemonModel.BaseHP,
                BaseAttack = pokemonModel.BaseAttack,
                BaseDefense = pokemonModel.BaseDefense,
                BaseSPAttack = pokemonModel.BaseSPAttack,
                BaseSPDefense = pokemonModel.BaseSPDefense,
                BaseSpeed = pokemonModel.BaseSpeed,
                OwnedPokemons = pokemonModel.OwnedPokemons.Select(x => x.ToOwnedPokemonDTO()).ToList(),
            };
        }

        public static Pokemon ToPokemonFromCreateDTO(this CreatePokemonDTO pokemonDTO)
        {
            return new Pokemon
            {
                PokemonNumber = pokemonDTO.PokemonNumber,
                PokemonName = pokemonDTO.PokemonName,
                PokemonInfo = pokemonDTO.PokemonInfo,
                PokemonType = pokemonDTO.PokemonType,
                PokemonType2 = pokemonDTO.PokemonType2,
                BaseHP = pokemonDTO.BaseHP,
                BaseAttack = pokemonDTO.BaseAttack,
                BaseDefense = pokemonDTO.BaseDefense,
                BaseSPAttack = pokemonDTO.BaseSPAttack,
                BaseSPDefense = pokemonDTO.BaseSPDefense,
                BaseSpeed = pokemonDTO.BaseSpeed,
            };
        }

        public static PokemonDTOInOwnedPokemon ToPokemonInOwnedFromPokemonDTO(this Pokemon pokemonDTO)
        {
            return new PokemonDTOInOwnedPokemon
            {
                PokemonNumber = pokemonDTO.PokemonNumber,
                PokemonName = pokemonDTO.PokemonName,
                PokemonInfo = pokemonDTO.PokemonInfo,
                PokemonType = pokemonDTO.PokemonType,
                PokemonType2 = pokemonDTO.PokemonType2,
                BaseHP = pokemonDTO.BaseHP,
                BaseAttack = pokemonDTO.BaseAttack,
                BaseDefense = pokemonDTO.BaseDefense,
                BaseSPAttack = pokemonDTO.BaseSPAttack,
                BaseSPDefense = pokemonDTO.BaseSPDefense,
                BaseSpeed = pokemonDTO.BaseSpeed,
            };
        }
    }
}
