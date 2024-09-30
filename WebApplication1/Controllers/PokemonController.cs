using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Pokemon;
using WebApplication1.Helpers;
using WebApplication1.Interface;
using WebApplication1.Mappers;

namespace WebApplication1.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepo;
        public PokemonController(IPokemonRepository pokemonRepo)
        {
            _pokemonRepo = pokemonRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PokemonQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemons = await _pokemonRepo.GetAllAsync(query);
            var pokemonDTO = pokemons.Select(s => s.ToPokemonDTO()).ToList();

            return Ok(pokemonDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemon = await _pokemonRepo.GetByIdAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon.ToPokemonDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePokemonDTO pokemonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemonModel = pokemonDto.ToPokemonFromCreateDTO();

            await _pokemonRepo.CreateAsync(pokemonModel);

            return CreatedAtAction(nameof(GetById), new { id = pokemonModel.Id }, pokemonModel.ToPokemonDTO());
        }
    }
}
