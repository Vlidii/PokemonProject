namespace WebApplication1.DTOs.Pokemon
{
    public class PokemonDTOInOwnedPokemon
    {
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; }
        public string PokemonInfo { get; set; }
        public string PokemonType { get; set; }
        public string PokemonType2 { get; set; } = string.Empty;
        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSPAttack { get; set; }
        public int BaseSPDefense { get; set; }
        public int BaseSpeed { get; set; }
    }
}
