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

            builder.HasIndex(i => i.SearchName)
                .IsUnique();

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

            builder.HasData(
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"), Name = "Pâtes", SearchName = "pates", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"), Name = "Riz", SearchName = "riz", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"), Name = "Semoule", SearchName = "semoule", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"), Name = "Poulet", SearchName = "poulet", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"), Name = "Thon", SearchName = "thon", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000006"), Name = "Oeufs", SearchName = "oeufs", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"), Name = "Tomates", SearchName = "tomates", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"), Name = "Oignon", SearchName = "oignon", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000009"), Name = "Ail", SearchName = "ail", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000010"), Name = "Poivron", SearchName = "poivron", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000011"), Name = "Carotte", SearchName = "carotte", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000012"), Name = "Courgette", SearchName = "courgette" },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000013"), Name = "Champignons", SearchName = "champignons", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000014"), Name = "Huile d'olive", SearchName = "huiledolive", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000015"), Name = "Beurre", SearchName = "beurre", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000016"), Name = "Crème", SearchName = "creme", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000017"), Name = "Lait", SearchName = "lait", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000018"), Name = "Parmesan", SearchName = "parmesan", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000019"), Name = "Mozzarella", SearchName = "mozzarella", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000020"), Name = "Pesto", SearchName = "pesto", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000021"), Name = "Sauce tomate", SearchName = "saucetomate", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000022"), Name = "Sel", SearchName = "sel", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000023"), Name = "Poivre", SearchName = "poivre", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000024"), Name = "Paprika", SearchName = "paprika", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000025"), Name = "Cumin", SearchName = "cumin", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000026"), Name = "Citron", SearchName = "citron", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000027"), Name = "Miel", SearchName = "miel", CreatedAt = DateTime.UtcNow },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000028"), Name = "Haricots rouges", SearchName = "haricotsrouges", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000029"), Name = "Maïs", SearchName = "mais", CreatedAt = DateTime.UtcNow },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000030"), Name = "Salade", SearchName = "salade", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
