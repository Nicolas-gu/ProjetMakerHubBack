using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class Plan
    {
        public Guid Id { get; set; }
        public DateOnly WeekStartDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public User User { get; set; } = null!;
        public Guid UserId { get; set; }
        public List<PlanSlot> Slots { get; set; } = new();
    }
}
