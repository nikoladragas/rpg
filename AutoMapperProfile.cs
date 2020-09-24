using System.Linq;
using AutoMapper;
using dotnet_core_rpg.Dtos.Character;
using dotnet_core_rpg.Dtos.Skill;
using dotnet_core_rpg.Dtos.Weapon;
using dotnet_core_rpg.Models;

namespace dotnet_core_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
          CreateMap<Character, GetCharacterDto>()
            .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
          CreateMap<AddCharacterDto, Character>();
          CreateMap<Weapon, GetWeaponDto>();
          CreateMap<Skill, GetSkillDto>();
        }
    }
}