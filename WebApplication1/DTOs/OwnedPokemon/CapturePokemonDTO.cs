using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Pokemon
{
    public class CapturePokemonDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Ability { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Nature { get; set; } = string.Empty;
        public bool Shiny { get; set; } = false;
        public DateTime CaptureDate { get; set; } = DateTime.Now;
        public int Level { get; set; } = 1;
        [Range(0, 31)]
        public int IVHP { get; set; } = 0;
        [Range(0, 252)]
        public int EVHP { get; set; } = 0;
        [Range(0, 31)]
        public int IVAttack { get; set; } = 0;
        [Range(0, 252)]
        public int EVAttack { get; set; } = 0;
        [Range(0, 31)]
        public int IVDefense { get; set; } = 0;
        [Range(0, 252)]
        public int EVDefense { get; set; } = 0;
        [Range(0, 31)]
        public int IVSPAttack { get; set; } = 0;
        [Range(0, 252)]
        public int EVSPAttack { get; set; } = 0;
        [Range(0, 31)]
        public int IVSPDefence { get; set; } = 0;
        [Range(0, 252)]
        public int EVSPDefence { get; set; } = 0;
        [Range(0, 31)]
        public int IVSpeed { get; set; } = 0;
        [Range(0, 252)]
        public int EVSpeed { get; set; } = 0;
    }
}
