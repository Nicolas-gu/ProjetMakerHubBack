using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class RecipeUpdateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int BasePortion { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public bool IsPublic { get; set; }
        public List<string> Steps { get; set; } = new();
        public List<string> Tags { get; set; } = new();
        public List<Guid> TagsIds { get; set; } = new();
        public List<RecipeIngredientUpdateDto> Ingredients { get; set; } = new();
    }

    public class RecipeIngredientUpdateDto
    {
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
        public string? QuantityText { get; set; }
        public Unit Unit { get; set; } = Unit.Unknown;
    }
}
