using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_core_rpg.Dtos.Character;
using dotnet_core_rpg.Models;
using dotnet_core_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_rpg.Controllers
{
    // With this Route attribute we can acces this controller by its name 'Character'
    // Only users with Role = Player can access this controller
    [Authorize(Roles = "Player, Admin")]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
          return Ok(await _characterService.GetAllCharacters());
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
          return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
          return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
          ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
          if(response.Data == null)
          {
            return NotFound(response);
          }

          return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);

          if (response.Data == null)
          {
            return NotFound(response);
          }
          return Ok(response);
        }
    }
}