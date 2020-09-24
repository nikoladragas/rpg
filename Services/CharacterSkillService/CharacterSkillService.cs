using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_core_rpg.Data;
using dotnet_core_rpg.Dtos.Character;
using dotnet_core_rpg.Dtos.CharacterSkill;
using dotnet_core_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_rpg.Services.CharacterSkillService
{
  public class CharacterSkillService : ICharacterSkillService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CharacterSkillService(IHttpContextAccessor httpContextAccessor, DataContext context, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
        ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
        try
        {
          Character character = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
            .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.Characterid && 
            c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
          if (character == null)
          {
            response.Success = false;
            response.Message = "Character not found.";
            return response;
          }
          Skill skill = await _context.Skills
            .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);
          if (skill == null)
          {
            response.Success = false;
            response.Message = "Skill not found";
          }
          CharacterSkill characterSkill = new CharacterSkill
          {
            Character = character,
            Skill = skill
          };
          await _context.CharacterSkills.AddAsync(characterSkill);
          await _context.SaveChangesAsync();

          response.Data = _mapper.Map<GetCharacterDto>(character);
        }
        catch (Exception e)
        {
          response.Success = false;
          response.Message = e.Message;
        }
        return response;
    }
  }
}