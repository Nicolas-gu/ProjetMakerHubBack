using System.ComponentModel.DataAnnotations;

namespace ProjetMakerHubBack.API.Dto
{
    public class IngredientCreateDTO
    {
        [Required]
        public string Name { get; set; }

    }
}
