using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class ShoppingListItemsDto
    {
        public class ShoppingListItemDto
        {
            public Guid Id { get; set; }
            public Guid IngredientId { get; set; }
            public string IngredientName { get; set; } = null!;
            public decimal? Quantity { get; set; }
            public Unit Unit { get; set; }
            public string? QuantityText { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}
