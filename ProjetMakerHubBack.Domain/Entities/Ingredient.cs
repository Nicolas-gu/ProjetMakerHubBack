using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string SearchName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
        public List<PantryItem> PantryItems { get; set; } = new();
        public List<ShoppingListItem> ShoppingListItems { get; set; } = new();

    }
}
