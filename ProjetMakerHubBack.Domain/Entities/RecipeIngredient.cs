using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class RecipeIngredient
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
    }
}
