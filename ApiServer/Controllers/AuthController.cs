using ApiServer.Models;
using ApiServer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiServer.Api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
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
    }
