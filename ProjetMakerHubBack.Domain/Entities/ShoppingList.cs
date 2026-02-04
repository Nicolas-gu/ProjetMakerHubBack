using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public DateOnly WeekStart { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public List<ShoppingListItem> Items { get; set; } = new();
    }
}
