using System.Threading.Tasks;
using dotnet_core_rpg.Dtos.CharacterSkill;
using dotnet_core_rpg.Services.CharacterSkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_rpg.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController : ControllerBase
    {
      private readonly ICharacterSkillService _characterSkillService;
        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            _characterSkillService = characterSkillService;
        }

        [HttpPost]
        public async Task<IActionResult> AdCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
          return Ok(await _characterSkillService.AddCharacterSkill(newCharacterSkill));
        }
    }
}