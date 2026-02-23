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

            var createdAt = new DateTime(2026, 02, 21, 10, 00, 00, DateTimeKind.Utc);

            builder.HasData(
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"), Name = "Pâtes", SearchName = "pates", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"), Name = "Riz", SearchName = "riz", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"), Name = "Quinoa", SearchName = "quinoa", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"), Name = "Boulgour", SearchName = "boulgour", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"), Name = "Tortillas", SearchName = "tortillas", CreatedAt = createdAt },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"), Name = "Poulet", SearchName = "poulet", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"), Name = "Thon", SearchName = "thon", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000009"), Name = "Bœuf haché", SearchName = "boeufhache", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000010"), Name = "Saumon", SearchName = "saumon", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000011"), Name = "Œufs", SearchName = "oeufs", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000012"), Name = "Tofu", SearchName = "tofu", CreatedAt = createdAt },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000013"), Name = "Haricots rouges", SearchName = "haricotsrouges", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000014"), Name = "Pois chiches", SearchName = "poischiches", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000015"), Name = "Lentilles", SearchName = "lentilles", CreatedAt = createdAt },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000016"), Name = "Oignon", SearchName = "oignon", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000017"), Name = "Ail", SearchName = "ail", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000018"), Name = "Tomate", SearchName = "tomate", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000019"), Name = "Tomates concassées", SearchName = "tomatesconcassees", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000020"), Name = "Concentré de tomate", SearchName = "concentredetomate", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000021"), Name = "Carotte", SearchName = "carotte", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000022"), Name = "Courgette", SearchName = "courgette", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000023"), Name = "Poivron", SearchName = "poivron", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000024"), Name = "Champignons", SearchName = "champignons", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000025"), Name = "Épinards", SearchName = "epinards", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000026"), Name = "Concombre", SearchName = "concombre", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000027"), Name = "Avocat", SearchName = "avocat", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000028"), Name = "Pommes de terre", SearchName = "pommesdeterre", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000029"), Name = "Maïs", SearchName = "mais", CreatedAt = createdAt },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000031"), Name = "Crème", SearchName = "creme", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000032"), Name = "Yaourt nature", SearchName = "yaourtnature", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000033"), Name = "Feta", SearchName = "feta", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000034"), Name = "Mozzarella", SearchName = "mozzarella", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000035"), Name = "Parmesan", SearchName = "parmesan", CreatedAt = createdAt },

                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000036"), Name = "Huile d'olive", SearchName = "huiledolive", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000037"), Name = "Vinaigre balsamique", SearchName = "vinaigrebalsamique", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000038"), Name = "Sauce soja", SearchName = "saucesoja", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000039"), Name = "Citron", SearchName = "citron", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000040"), Name = "Miel", SearchName = "miel", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000041"), Name = "Cumin", SearchName = "cumin", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000042"), Name = "Paprika", SearchName = "paprika", CreatedAt = createdAt },
                new Ingredient { Id = Guid.Parse("b0000000-0000-0000-0000-000000000043"), Name = "Curry", SearchName = "curry", CreatedAt = createdAt }
            );
        }
    }
}
