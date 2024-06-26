using ApiServer.Models.DTO;
using ApiServer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiServer.Api.Controllers;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        // Fixed constructor to inject both IAuthService and ITokenService
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest("Invalid user data.");
            }

            var success = await _authService.RegisterUser(user);
            if (success)
            {
                return Ok("Successfully registered.");
            }

            return BadRequest("Registration failed.");
        }
        [HttpPost("RegisterIUser")]
        public async Task<bool> RegisterUser(IdentityUser user)
        {
           
            var success = await _authService.RegisterUser(user);
               return success;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login( LoginUser user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest("Invalid user data.");
            }

            var success = await _authService.Login(user);
            if (success)
            {
                var tokenString = _authService.GenerateToken(user);
                return Ok(new { Token = tokenString });
            }

            return BadRequest("Login failed.");
        }
        [HttpGet("GetIUserById/{id}")]
        public async Task<IdentityUser> GetIuser(string id)
        {
           
            return  await _authService.GetIUserById(id);
               
        }
         [HttpGet("GetIUserByPhone/{phone}")]
        public async Task<IdentityUser> GetIuserByPhoneNum(string phone)
        {
           
            return  await _authService.GetIUserByPhone(phone);
               
        }
        [HttpGet("GetIUserByUsername/{username}")]
        public async Task<IdentityUser> GetIuserByUsername(string username)
        {
           
            return  await _authService.GetIUserByUsername(username);
               
        }

        [HttpGet("CreateRole/{id}")]
        public async Task<IdentityUser> CreateRole(string id)
        {
           
            return  await _authService.GetIUserById(id);
               
        }
        [HttpGet("IsInRole/{userId}/{rolename}")]
        public async Task<bool> IsInRole(string userId, string rolename)
        {
           
            var success = await _authService.IsInRole(userId, rolename);
               return success;
        }

        [HttpGet("GetIRoleById/{id}")]
        public async Task<IdentityRole> GetIRoleById(string id)
        {
           
            return  await _authService.GetIRoleById(id);
               
        }
        [HttpGet("GetIRoleByName/{rolename}")]
        public async Task<IdentityRole> GetIRoleByName(string rolename)
        {
           
            return  await _authService.GetIRoleByName(rolename);
               
        } 
        [HttpGet("GetRolesAsync/{userId}")]
        public async Task<List<string>> GetRolesAsync(string userId)
        {
            return  await _authService.GetRolesAsync(userId);
            
        }
    }
