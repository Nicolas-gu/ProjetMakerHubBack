using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(i => i.SearchName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(i => i.RecipeIngredients)
                .WithOne(ri => ri.Ingredient)
                .HasForeignKey(ri => ri.IngredientId);

            builder.HasMany(i => i.PantryItems)
                .WithOne(pi => pi.Ingredient)
                .HasForeignKey(pi => pi.IngredientId);

            builder.HasMany(i => i.ShoppingListItems)
                .WithOne(sli => sli.Ingredient)
                .HasForeignKey(sli => sli.IngredientId);

        }
    }
}
