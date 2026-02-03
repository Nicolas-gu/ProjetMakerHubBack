using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class ShoppingList
    {
        public Guid Id { get; set; }
        public DateOnly WeekStart { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingListItem>? Items { get; set; }
    }
}
