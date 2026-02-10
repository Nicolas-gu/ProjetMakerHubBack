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
                .WithMany(t => t.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "RecipeTags",
                    j => j.HasOne<Tag>()
                          .WithMany()
                          .HasForeignKey("TagId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Recipe>()
                          .WithMany()
                          .HasForeignKey("RecipeId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("RecipeId", "TagId");
                        j.ToTable("RecipeTags");
                    }
                );

            builder.HasMany(r => r.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId);

            builder.HasMany(r => r.PlanSlots)
                .WithOne(ps => ps.Recipe)
                .HasForeignKey(ps => ps.RecipeId);

            builder.HasMany(r => r.UserRecipes)
                .WithOne(ur => ur.Recipe)
                .HasForeignKey(ur => ur.RecipeId);

            builder.HasData(
                new Recipe
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"),
                    Title = "Pâtes au pesto",
                    Description = "Classique rapide et efficace.",
                    BasePortion = 2,
                    PrepTime = 5,
                    CookTime = 10,
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = Guid.Parse("62D01393-E0D0-4E0A-AD38-6E8507C4FCC2")
                },
                new Recipe
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"),
                    Title = "Riz sauté au poulet",
                    Description = "Parfait pour écouler le frigo.",
                    BasePortion = 2,
                    PrepTime = 10,
                    CookTime = 15,
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = Guid.Parse("62D01393-E0D0-4E0A-AD38-6E8507C4FCC2")
                },
                new Recipe
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"),
                    Title = "Omelette champignons-fromage",
                    Description = "Simple, rapide, protéinée.",
                    BasePortion = 1,
                    PrepTime = 5,
                    CookTime = 8,
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = Guid.Parse("62D01393-E0D0-4E0A-AD38-6E8507C4FCC2")
                },
                new Recipe
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"),
                    Title = "Salade thon maïs citron",
                    Description = "Healthy et frais.",
                    BasePortion = 2,
                    PrepTime = 10,
                    CookTime = 0,
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = Guid.Parse("DA32C7E3-2FF5-4BD0-9B2B-E407CDC36DF4")
                },
                new Recipe
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000005"),
                    Title = "Chili rapide",
                    Description = "Version simple sans prise de tête.",
                    BasePortion = 3,
                    PrepTime = 10,
                    CookTime = 20,
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = Guid.Parse("DA32C7E3-2FF5-4BD0-9B2B-E407CDC36DF4")
                },
                new Recipe
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000006"),
                    Title = "Poulet miel-citron",
                    Description = "Sucré-salé facile.",
                    BasePortion = 2,
                    PrepTime = 10,
                    CookTime = 15,
                    IsPublic = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = Guid.Parse("DA32C7E3-2FF5-4BD0-9B2B-E407CDC36DF4")
                }
            );
        }
    }
}
