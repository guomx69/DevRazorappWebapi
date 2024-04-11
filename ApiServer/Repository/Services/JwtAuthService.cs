using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


using ApiServer.Repository.Interfaces;
using ApiServer.Models.DTO;
//write the implementation of IAuthService with namespace ApiServer.Repository.Service
namespace ApiServer.Repository.Service;

    //write the implementation of IAuthService with namespace ApiServer.Repository.Service
    
    public class JwtAuthService : IAuthService
    {
         private readonly UserManager<IdentityUser> _userManager;
         private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public JwtAuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,IConfiguration config)
        {
            _userManager = userManager;
            _roleManager=roleManager;
            _config = config;
        }

        public async Task<bool> RegisterUser(LoginUser user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.PhNo,
                PhoneNumber=user.PhNo
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
        public async Task<bool> RegisterUser(IdentityUser user)
        {
          
            var result = await _userManager.CreateAsync(user); //user already has the hashed password, not need any more.
            return result.Succeeded;
             //if (result.Succeeded) await _userManager.AddToRoleAsync(user, "Admin");
        }


        public async Task<IdentityUser> GetIUserById( string id)
        {
          
           return await _userManager.FindByIdAsync(id);
        }
        public async Task<IdentityUser> GetIUserByPhone( string phone)
        {
          
           return await _userManager.FindByNameAsync(phone);
        }
         public async Task<IdentityUser> GetIUserByUsername( string username)
        {
          
           return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> Login(LoginUser user)
        {
            var identityUser = await _userManager.FindByNameAsync(user.PhNo);
            if (identityUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateToken(LoginUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.HomePhone,user.PhNo),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }



       
        public async Task<bool> AddRole(IdentityRole role)
        {
            var result = await _roleManager.CreateAsync(role); //user already has the hashed password, not need any more.
            return result.Succeeded;
           
        }

       
        public async Task<IdentityRole> GetIRoleById(string id)
        {
           
            return await _roleManager.FindByIdAsync(id);
               
        }
        public async Task<IdentityRole> GetIRoleByName(string rolename)
        {
           
           return await _roleManager.FindByNameAsync(rolename);
               
        }

        public async Task<bool> IsInRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return false;
            }
            return await _userManager.IsInRoleAsync(user, roleName);
        }
         public async Task<List<string>> GetRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return new List<string>();
            }
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        
    }

