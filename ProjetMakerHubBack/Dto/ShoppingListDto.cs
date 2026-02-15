using static ProjetMakerHubBack.API.Dto.ShoppingListItemsDto;

namespace ProjetMakerHubBack.API.Dto
{
    public class ShoppingListDto
    {
        public Guid Id { get; set; }
        public DateOnly WeekStart { get; set; }
        public List<ShoppingListItemDto> Items { get; set; } = new();
    }
}
