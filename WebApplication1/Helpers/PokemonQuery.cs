﻿namespace WebApplication1.Helpers
{
    public class PokemonQuery
    {
        public string? PokemonName { get; set; } = null;
        public string? PokemonType1 { get; set; } = null;
        public string? PokemonType2 { get; set; } = null;
        public string? SortBy { get; set;} = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}
