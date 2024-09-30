using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Pokemon
{
    public class OwnedPokemonDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Ability { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Nature { get; set; } = string.Empty;
        public bool Shiny { get; set; } = false;
        public DateTime CaptureDate { get; set; } = DateTime.Now;
        [Range(1, 100)]
        public int Level { get; set; } = 1;
        public int HP { get; set; }
        [Range(0, 31)]
        public int IVHP { get; set; } = 0;
        [Range(0, 252)]
        public int EVHP { get; set; } = 0;
        public int Attack { get; set; }
        [Range(0, 31)]
        public int IVAttack { get; set; } = 0;
        [Range(0, 252)]
        public int EVAttack { get; set; } = 0;
        public int Defense { get; set; }
        [Range(0, 31)]
        public int IVDefense { get; set; } = 0;
        [Range(0, 252)]
        public int EVDefense { get; set; } = 0;
        public int SPAttack { get; set; }
        [Range(0, 31)]
        public int IVSPAttack { get; set; } = 0;
        [Range(0, 252)]
        public int EVSPAttack { get; set; } = 0;
        public int SPDefence { get; set; }
        [Range(0, 31)]
        public int IVSPDefence { get; set; } = 0;
        [Range(0, 252)]
        public int EVSPDefence { get; set; } = 0;
        public int Speed { get; set; }
        [Range(0, 31)]
        public int IVSpeed { get; set; } = 0;
        [Range(0, 252)]
        public int EVSpeed { get; set; } = 0;
        public PokemonDTOInOwnedPokemon? Pokemon { get; set; }
        public string TrainerName = string.Empty;
    }
}
