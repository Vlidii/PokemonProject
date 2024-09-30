using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/pokemonteam")]
    [ApiController]
    public class PokemonTeamController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOwnedPokemonRepository _ownedPokemonRepo;
        private readonly IPokemonTeamRepository _pokemonTeamRepo;
        public PokemonTeamController(UserManager<AppUser> userManager,
        IOwnedPokemonRepository ownedPokemonRepo, IPokemonTeamRepository pokemonTeamRepo)
        {
            _userManager = userManager;
            _ownedPokemonRepo = ownedPokemonRepo;
            _pokemonTeamRepo = pokemonTeamRepo;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemonTeams = await _pokemonTeamRepo.GetAllAsync();

            return Ok(pokemonTeams);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemonTeam = await _pokemonTeamRepo.GetByIdAsync(id);

            if (pokemonTeam == null)
            {
                return NotFound();
            }
            return Ok(pokemonTeam);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemonTeam = await _pokemonTeamRepo.GetByUserIdAsync(id);

            if (pokemonTeam == null)
            {
                return NotFound();
            }
            return Ok(pokemonTeam);
        }
    }
}
