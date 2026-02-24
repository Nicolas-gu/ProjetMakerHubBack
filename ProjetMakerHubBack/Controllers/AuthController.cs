using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Services;
using System.Security.Authentication;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService _authService) : ControllerBase
    {
        [HttpPost("login")]
        [EndpointDescription("Authenticate a user and return a JWT token.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                string token = await _authService.LoginAsync(dto.Email, dto.Password);
                return Ok(new { token });
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        [EndpointDescription("Register a new user.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var token = await _authService.RegisterAsync(dto.DisplayName, dto.Email, dto.Password);
                return Ok(new { token });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("me")]
        [EndpointDescription("Get user information.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
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
