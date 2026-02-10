using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;
using ProjetMakerHubBack.Domain.Enums;

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

            builder.HasData(
                // Pâtes pesto
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000001"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000020"), BaseQuantity = 60, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000018"), BaseQuantity = 20, Unit = Unit.Gram },

                // Riz sauté poulet
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000004"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000009"), BaseQuantity = 1, Unit = Unit.Piece },

                // Omelette champignons-fromage
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000006"), BaseQuantity = 3, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000013"), BaseQuantity = 150, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000019"), BaseQuantity = 80, Unit = Unit.Gram },

                // Salade thon maïs citron
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000030"), BaseQuantity = 1, Unit = Unit.Piece, QuantityText = "1 bol" },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000005"), BaseQuantity = 160, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000029"), BaseQuantity = 120, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece },

                // Chili rapide
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000010"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000021"), BaseQuantity = 300, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000028"), BaseQuantity = 240, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000029"), BaseQuantity = 120, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000025"), BaseQuantity = null, Unit = Unit.Unknown, QuantityText = "1 c.à.c" },

                // Poulet miel-citron
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000004"), BaseQuantity = 250, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000027"), BaseQuantity = 1, Unit = Unit.Tablespoon },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece }
            );
        }
    }
}
