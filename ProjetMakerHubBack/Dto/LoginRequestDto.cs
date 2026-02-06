using System.ComponentModel.DataAnnotations;

namespace ProjetMakerHubBack.API.Dto
{
    public class LoginRequestDTO
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
