using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ProjetMakerHubBack.Domain.Entities;
using System.Reflection;

namespace ProjetMakerHubBack.API.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<PantryItem> PantryItems { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PlanSlot> PlanSlots { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<RecipeStep> RecipeSteps { get; set; }
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
        public virtual DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRecipe> UserRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ajoute les config des entités
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
