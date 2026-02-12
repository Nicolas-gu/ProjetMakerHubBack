using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class PlanSlotAddDto
    {
        public DateOnly Date { get; set; }
        public SlotType Type { get; set; }
        public int Portion { get; set; }
        public Guid RecipeId { get; set; }
    }
}
