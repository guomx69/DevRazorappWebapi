using ApiServer.Models.DTO;
using Microsoft.AspNetCore.Identity;
//create an interface IAuthService with namespace ApiServer.Repository.Interfaces  
namespace ApiServer.Repository.Interfaces
{
    public interface IAuthService
    {
        //create Login method with parameter LoginUser and return Task<bool>
        Task<bool> Login(LoginUser user);
        //create Register method with parameter LoginUser and return Task<bool>
        Task<bool> RegisterUser(LoginUser user);
        
        Task<bool> RegisterUser(IdentityUser user);

        Task<IdentityUser> GetIUserById(string id);
        Task<IdentityUser> GetIUserByPhone(string phone);
        Task<IdentityUser> GetIUserByUsername(string username);


        //create GenerateToken method with parameter LoginUser user and return string   
        string GenerateToken(LoginUser user);

        
        Task<bool> AddRole(IdentityRole role);
        Task<IdentityRole> GetIRoleById(string id);
        Task<IdentityRole> GetIRoleByName(string rolename);

        Task<bool> IsInRole(string userId, string role);
        Task<List<string>> GetRolesAsync(string userId);
       
    }
}