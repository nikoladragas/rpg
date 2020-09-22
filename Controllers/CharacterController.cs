using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_core_rpg.Models;
using dotnet_core_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_rpg.Controllers
{
    // With this Route attribute we can acces this controller by its name 'Character'
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
          return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
          return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {
          return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}