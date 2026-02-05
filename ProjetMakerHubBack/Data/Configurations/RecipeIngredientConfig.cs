using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class RecipeIngredientConfig : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            builder.HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);


        }
    }
}
