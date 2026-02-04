using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class PlanSlot
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public SlotType Type { get; set; }
        public int Portion { get; set; }


        public Guid PlanId { get; set; }
        public Guid? RecipeId { get; set; }
        public Plan Plan { get; set; } = null!;
        public Recipe? Recipe { get; set; }
    }
}
