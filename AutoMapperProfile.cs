using AutoMapper;
using dotnet_core_rpg.Dtos.Character;
using dotnet_core_rpg.Models;

namespace dotnet_core_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
          CreateMap<Character, GetCharacterDto>();
          CreateMap<AddCharacterDto, Character>();
        }
    }
}