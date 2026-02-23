using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Dto
{
    public class RecipeDetailResponseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BasePortion { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFavorite { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public List<string> Steps { get; set; } = new();
        public List<string> Tags { get; set; } = new();
        public List<Guid> TagIds { get; set; } = new();
        public List<IngredientDetailDto> Ingredients { get; set; } = new();
    }

    public class IngredientDetailDto
    {
        public string Name { get; set; } = null!;
        public decimal? Quantity { get; set; }
        public string? QuantityText { get; set; }
        public int Unit { get; set; }
    }
}
