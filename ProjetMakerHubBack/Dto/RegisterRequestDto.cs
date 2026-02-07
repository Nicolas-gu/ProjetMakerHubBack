using System.ComponentModel.DataAnnotations;

namespace ProjetMakerHubBack.API.Dto
{
    public class RegisterRequestDTO
    {
        [Required]
        public string DisplayName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
