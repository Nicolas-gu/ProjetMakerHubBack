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

            var createdAt = new DateTime(2026, 02, 21, 10, 00, 00, DateTimeKind.Utc);
            var userId = Guid.Parse("DA32C7E3-2FF5-4BD0-9B2B-E407CDC36DF4");

            builder.HasData(
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"), Title = "Pâtes tomate basilic", Description = "Sauce tomate maison à l’ail et basilic. Simple et parfumé.", BasePortion = 2, PrepTime = 10, CookTime = 20, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"), Title = "Chili sin carne", Description = "Haricots rouges, tomate, épices. Parfait en batch cooking.", BasePortion = 3, PrepTime = 10, CookTime = 25, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"), Title = "Salade quinoa feta citron", Description = "Quinoa, concombre, tomate, feta, citron. Lunch frais.", BasePortion = 2, PrepTime = 15, CookTime = 15, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"), Title = "Omelette champignons épinards", Description = "Omelette moelleuse, champignons et épinards. Rapide.", BasePortion = 1, PrepTime = 8, CookTime = 10, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000005"), Title = "Poulet citron-miel & riz", Description = "Poulet caramélisé soja-miel-citron, servi avec riz.", BasePortion = 2, PrepTime = 10, CookTime = 20, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },

                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000006"), Title = "Bolognaise maison", Description = "Sauce bolognaise au bœuf haché, idéale avec pâtes.", BasePortion = 4, PrepTime = 15, CookTime = 35, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000007"), Title = "Curry de lentilles & épinards", Description = "Curry doux, lentilles et épinards, servi avec riz.", BasePortion = 4, PrepTime = 10, CookTime = 30, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000008"), Title = "Wrap thon avocat", Description = "Wrap express : thon, avocat, tomate, citron.", BasePortion = 2, PrepTime = 12, CookTime = 0, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000009"), Title = "Salade pois chiches", Description = "Pois chiches, concombre, tomate, cumin et citron.", BasePortion = 3, PrepTime = 15, CookTime = 0, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000010"), Title = "Riz sauté aux œufs", Description = "Riz sauté rapide avec légumes et sauce soja.", BasePortion = 2, PrepTime = 10, CookTime = 12, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },

                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000011"), Title = "Poulet paprika & poivrons", Description = "Poêlée simple : poulet, poivron, paprika, tomate.", BasePortion = 3, PrepTime = 12, CookTime = 20, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000012"), Title = "Bowl saumon quinoa avocat", Description = "Bowl équilibré : saumon, quinoa, avocat, crudités.", BasePortion = 2, PrepTime = 15, CookTime = 12, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000013"), Title = "Gratin pommes de terre mozzarella", Description = "Gratin fondant, simple et familial.", BasePortion = 4, PrepTime = 20, CookTime = 45, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000014"), Title = "Pâtes crème champignons parmesan", Description = "Sauce crémeuse champignons et parmesan.", BasePortion = 2, PrepTime = 10, CookTime = 18, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId },
                new Recipe { Id = Guid.Parse("c0000000-0000-0000-0000-000000000015"), Title = "Taboulé boulgour", Description = "Taboulé frais : boulgour, tomate, concombre, citron.", BasePortion = 4, PrepTime = 20, CookTime = 0, IsPublic = true, CreatedAt = createdAt, CreatedByUserId = userId }
            );
        }
    }
}
