using System.Threading.Tasks;
using dotnet_core_rpg.Models;

namespace dotnet_core_rpg.Data
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(User user, string password);
         Task<ServiceResponse<string>> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}