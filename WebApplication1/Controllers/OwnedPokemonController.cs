using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Pokemon;
using WebApplication1.Extension;
using WebApplication1.Helpers;
using WebApplication1.Interface;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/ownedpokemon")]
    [ApiController]
    public class OwnedPokemonController : Controller
    {
        private readonly IOwnedPokemonRepository _ownedPokemonRepo;
        private readonly IPokemonRepository _pokemonRepo;
        private readonly UserManager<AppUser> _userManager;
        public OwnedPokemonController(IOwnedPokemonRepository ownedPokemonRepo, IPokemonRepository pokemonRepo, UserManager<AppUser> userManager)
        {
            _ownedPokemonRepo = ownedPokemonRepo;
            _pokemonRepo = pokemonRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OwnedPokemonQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemons = await _ownedPokemonRepo.GetAllAsync(query);
            var pokemonDTO = pokemons.Select(s => s.ToOwnedPokemonDTO());

            return Ok(pokemonDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _ownedPokemonRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToOwnedPokemonDTO());
        }

        [HttpPost("{pokemonId:int}")]
        public async Task<IActionResult> Create([FromRoute] int pokemonId, CapturePokemonDTO pokemonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _pokemonRepo.PokemonExists(pokemonId))
            {
                return BadRequest("Pokemon does not exists");
            }

            //get and add user to owned pokemon
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var pokemonModel = pokemonDto.ToOwnedPokemonFromCaptureDTO(pokemonId);
            pokemonModel.AppUserId = appUser.Id;

            pokemonModel.Pokemon = await _pokemonRepo.GetByIdAsync(pokemonId);

            await _ownedPokemonRepo.CreateAsync(pokemonModel);

            return CreatedAtAction(nameof(GetById), new { id = pokemonModel.Id }, pokemonModel.ToOwnedPokemonDTO());
        }
    }
}

 