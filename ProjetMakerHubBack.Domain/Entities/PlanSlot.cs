using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class PlanSlot
    {
        public Guid Id { get; set; }
        public Guid PlanId { get; set; }
        public DateTime Date { get; set; }
        public SlotType Type { get; set; }
        public Guid RecipeId { get; set; }
        public int Portion { get; set; }

    }
}
