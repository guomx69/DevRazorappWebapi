    
using Microsoft.AspNetCore.Identity;
namespace WebApp.AccessLayer;
    interface IRoleDataAccess
    {
        //public bool CreateUser(IdentityRole user);
        public Task<bool> CreateRoleAsync(IdentityRole user);
        //public bool CreateUser(IdentityRole user);
        //public IdentityRole GetUserById(string id);
        public Task<IdentityRole> GetRoleById(string id);
        
        public  Task<IdentityRole> GetRoleByRolename(string username);
        public string GetNormalizedRolename(IdentityRole user);
        public bool Update(IdentityRole user);

    }