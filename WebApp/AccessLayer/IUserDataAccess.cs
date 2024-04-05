    
using Microsoft.AspNetCore.Identity;
namespace WebApp.AccessLayer;
    interface IUserDataAccess
    {
        //public bool CreateUser(IdentityUser user);
        public Task<bool> CreateUserAsync(IdentityUser user);
        //public bool CreateUser(IdentityUser user);
        //public IdentityUser GetUserById(string id);
        public Task<IdentityUser> GetUserById(string id);
        
        public Task<IdentityUser> GetByPhoneNumber(string phone);
        
        public  Task<IdentityUser> GetUserByUsername(string username);
        public string GetNormalizedUsername(IdentityUser user);
        public bool Update(IdentityUser user);

    }