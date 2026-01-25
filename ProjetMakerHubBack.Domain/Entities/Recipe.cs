using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class Recipe
    {
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int BasePortion { get; set; }
        public required int PrepTime { get; set; }
        public required int CookTime { get; set; }
        //public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; } = null!;
        public List<RecipeStep>? Steps { get; set; }
        public List<RecipeIngredient>? RecipeIngredients { get; set; }
        public List<RecipeFavorite>? Favorites { get; set; }
        public List<RecipeTag>? Tags { get; set; }
        public List<PlanSlot>? Slots { get; set; }



    }
}
