using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class UserRecipeConfig : IEntityTypeConfiguration<UserRecipe>
    {
        public void Configure(EntityTypeBuilder<UserRecipe> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RecipeId });

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRecipes)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Recipe)
                .WithMany(r => r.UserRecipes)
                .HasForeignKey(ur => ur.RecipeId);
        }
    }
}
