using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Application.Services;
using System.Security.Authentication;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService _authService) : ControllerBase
    {
        [HttpPost("login")]
        [Consumes(typeof(LoginRequestDTO), "application/json")]
        [EndpointSummary("Authenticates a user and returns a JWT token.")]
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
    }
}
