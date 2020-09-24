using System.Threading.Tasks;
using dotnet_core_rpg.Dtos.Character;
using dotnet_core_rpg.Dtos.Weapon;
using dotnet_core_rpg.Models;

namespace dotnet_core_rpg.Services.WeaponService
{
    public interface IWeaponService
    {
         Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}