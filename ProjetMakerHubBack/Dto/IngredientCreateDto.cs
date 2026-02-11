using System.ComponentModel.DataAnnotations;

namespace ProjetMakerHubBack.API.Dto
{
    public class IngredientCreateDto
    {
        [Required]
        public string Name { get; set; }

    }
}
