using ProjetMakerHubBack.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetMakerHubBack.API.Dto
{
    public class RecipeCreateDTO
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int BasePortion { get; set; }
        [Required]
        public int PrepTime { get; set; }
        [Required]
        public int CookTime { get; set; }
        public bool IsPublic { get; set; }
        public List<Guid> TagIds { get; set; } = new();
        public List<string> Steps { get; set; } = new();
        public List<RecipeIngredientCreateDto> Ingredients { get; set; } = new();
    }

    public class RecipeIngredientCreateDto
    {
        public Guid IngredientId { get; set; }
        public decimal? BaseQuantity { get; set; }
        public Unit Unit { get; set; } = Unit.Unknown;
        public string? QuantityText { get; set; }
    }
}
