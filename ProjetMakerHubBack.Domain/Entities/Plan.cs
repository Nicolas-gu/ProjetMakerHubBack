using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class Plan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateOnly StartPlan {  get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PlanSlot>? Slots { get; set; }


    }
}
