using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.BasePortion)
                .IsRequired();

            builder.Property(r => r.PrepTime)
                .IsRequired();

            builder.Property(r => r.CookTime)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(u => u.CreatedByUserId);

            builder.HasMany(r => r.RecipeSteps)
                .WithOne(rs => rs.Recipe)
                .HasForeignKey(rs => rs.RecipeId);

            builder.HasMany(r => r.Tags)
                .WithMany(t => t.Recipes);

            builder.HasMany(r => r.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId);

            builder.HasMany(r => r.PlanSlots)
                .WithOne(ps => ps.Recipe)
                .HasForeignKey(ps => ps.RecipeId);

            builder.HasMany(r => r.UserRecipes)
                .WithOne(ur => ur.Recipe)
                .HasForeignKey(ur => ur.RecipeId);


        }
    }
}
