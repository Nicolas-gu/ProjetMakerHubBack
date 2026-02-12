using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Dto
{
    public class PlanWeekDto
    {
        public Guid PlanId { get; set; }
        public DateOnly WeekStartDate { get; set; }
        public List<PlanSlotDto> Slots { get; set; } = new();
    }

    public class PlanSlotDto
    {
        public Guid SlotId { get; set; }
        public DateOnly Date { get; set; }
        public SlotType Type { get; set; }
        public int Portion { get; set; }
        public Guid? RecipeId { get; set; }
        public string RecipeTitle { get; set; } = null!;
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
    }
}
