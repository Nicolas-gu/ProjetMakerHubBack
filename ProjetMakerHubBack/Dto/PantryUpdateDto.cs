using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class PantryUpdateDto
    {
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
    }
}
