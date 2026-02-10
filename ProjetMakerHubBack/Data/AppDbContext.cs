using Microsoft.EntityFrameworkCore;
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

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("RecipeTags").HasData(
                // Pâtes pesto : Italien + Rapide + Facile
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111126") }, // Italien
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111117") }, // Rapide
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111118") }, // Facile

                // Riz sauté : Asiatique + Facile
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111127") }, // Asiatique
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111118") }, // Facile

                // Omelette : Protéiné + Rapide
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111116") }, // Protéiné
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111117") }, // Rapide

                // Salade : Healthy + Rapide
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111115") }, // Healthy
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111117") }, // Rapide

                // Chili : Mexicain
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111128") }, // Mexicain

                // Poulet miel-citron : Facile
                new { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), TagId = Guid.Parse("11111111-1111-1111-1111-111111111118") }  // Facile
            );
        }

    }
}
