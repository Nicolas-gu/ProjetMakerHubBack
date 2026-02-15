using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class PantryItemDto
    {
        public Guid Id { get; set; }
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; } = null!;
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
