using ApiServer.Models.DTO;
//create an interface IAuthService with namespace ApiServer.Repository.Interfaces  
namespace ApiServer.Repository.Interfaces
{
    public interface IAuthService
    {
        //create Login method with parameter LoginUser and return Task<bool>
        Task<bool> Login(LoginUser user);
        //create Register method with parameter LoginUser and return Task<bool>
        Task<bool> RegisterUser(LoginUser user);
        


        //create GenerateToken method with parameter LoginUser user and return string   
        string GenerateToken(LoginUser user);
    }
}