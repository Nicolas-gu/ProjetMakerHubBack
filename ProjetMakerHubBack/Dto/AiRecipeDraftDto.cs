using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class AiRecipeDraftDto
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int BasePortion { get; set; } = 2;
        public int PrepTime { get; set; }
        public int CookTime { get; set; }

        public List<string> Steps { get; set; } = new();
        public List<string> TagNames { get; set; } = new();
        public List<AiRecipeIngredientDto> Ingredients { get; set; } = new();
    }

    public class AiRecipeIngredientDto
    {
        public string Name { get; set; } = "";
        public decimal? Quantity { get; set; }
        public Unit? Unit { get; set; }
        public string? QuantityText { get; set; }
    }
}
