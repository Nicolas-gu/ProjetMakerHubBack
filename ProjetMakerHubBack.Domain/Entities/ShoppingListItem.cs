using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class ShoppingListItem
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
        public bool IsChecked { get; set; }
        public Guid ShoppingListId { get; set; }
        public Guid IngredientId { get; set; }
    }
}
