using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class RecipeIngredient
    {
        public decimal? BaseQuantity { get; set; }
        public Unit? Unit { get; set; }
        public string? QuantityText { get; set; }

        public Recipe Recipe { get; set; } = null!;
        public Ingredient Ingredient { get; set; } = null!;

        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
    }
}
