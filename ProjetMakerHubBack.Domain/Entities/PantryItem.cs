using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class PantryItem
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;


        public Guid UserId { get; set; }
        public Guid IngredientId { get; set; }
        public User User { get; set; } = null!;
        public Ingredient Ingredient { get; set; } = null!;


    }
}
