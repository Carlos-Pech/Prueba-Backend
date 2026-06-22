using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Core.Interfaces;
using backend.DTOs.Auth;
namespace backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService  _authService;
        public AuthController( IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
           var result = await _authService.LoginAsync(request);

            if(result == null)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(result);
        }

    }
}