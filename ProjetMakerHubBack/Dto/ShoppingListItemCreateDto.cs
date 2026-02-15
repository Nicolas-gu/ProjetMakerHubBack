using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class ShoppingListItemCreateDto
    {
        public Guid? IngredientId { get; set; }
        public string? IngredientName { get; set; }

        public decimal? Quantity { get; set; }
        public Unit? Unit { get; set; }
        public string? QuantityText { get; set; }
    }
}
