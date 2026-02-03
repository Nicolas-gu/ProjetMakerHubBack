using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class Ingredient
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string SearchName { get; set; }


        public List<RecipeIngredient>? RecipeIngredients { get; set; }
        public List<HomeStock>? Stocks { get; set; }
        public List<ShoppingListItem>? ShoppingListItems { get; set; }

    }
}
