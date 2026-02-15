using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class ShoppingListItemUpdateDto
    {
        public decimal? Quantity { get; set; }
        public Unit? Unit { get; set; }
        public string? QuantityText { get; set; }
        public bool? IsChecked { get; set; }
    }
}
