using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BasePortion { get; set; }
        public required int PrepTime { get; set; }
        public required int CookTime { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }


        public User? User { get; set; } = null!;
        public List<RecipeStep> RecipeSteps { get; set; } = new();
        public List<Tag> Tags { get; set; } = null!;
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
        public List<PlanSlot> PlanSlots { get; set; } = null!;
        public List<UserRecipe> UserRecipes { get; set; } = null!;
    }
}
