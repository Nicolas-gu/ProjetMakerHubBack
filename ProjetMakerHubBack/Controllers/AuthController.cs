using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Application.Services;
using System.Security.Authentication;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService _authService) : ControllerBase
    {
        [HttpPost("login")]
        [Consumes(typeof(LoginRequestDTO), "application/json")]
        [EndpointSummary("Authenticate a user and return a JWT token.")]
        public IActionResult Login([FromBody] LoginRequestDTO dto)
        {
            try
            {
                string token = _authService.Login(dto.Email, dto.Password);
                return Ok(new { token });
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        [EndpointSummary("Register a new user.")]
        public IActionResult Register([FromBody] RegisterRequestDTO dto)
        {
            try
            {
                var token = _authService.Register(dto.DisplayName, dto.Email, dto.Password);
                return Ok(new { token });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var name = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);

            return Ok(new
            {
                userId,
                email,
                name,
                role
            });
        }
    }
}
