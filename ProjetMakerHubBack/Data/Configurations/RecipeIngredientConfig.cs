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
                // 1 Pâtes tomate basilic
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000001"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000019"), BaseQuantity = 400, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000020"), BaseQuantity = 20, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000017"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000035"), BaseQuantity = 25, Unit = Unit.Gram },

                // 2 Chili sin carne
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000013"), BaseQuantity = 400, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000019"), BaseQuantity = 400, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000020"), BaseQuantity = 20, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000017"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000023"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000041"), BaseQuantity = 2, Unit = Unit.Teaspoon },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000042"), BaseQuantity = 1, Unit = Unit.Teaspoon },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 3 Salade quinoa feta citron
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000003"), BaseQuantity = 160, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000018"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000033"), BaseQuantity = 120, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000039"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 4 Omelette champignons épinards
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000011"), BaseQuantity = 3, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000024"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000025"), BaseQuantity = 150, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 5, Unit = Unit.Milliliter },

                // 5 Poulet citron-miel & riz
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000007"), BaseQuantity = 300, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000038"), BaseQuantity = 30, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000040"), BaseQuantity = 15, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000039"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 10, Unit = Unit.Milliliter },

                // 6 Bolognaise maison
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000009"), BaseQuantity = 500, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000019"), BaseQuantity = 600, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000020"), BaseQuantity = 30, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000017"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000001"), BaseQuantity = 400, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000035"), BaseQuantity = 40, Unit = Unit.Gram },

                // 7 Curry lentilles & épinards
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000015"), BaseQuantity = 250, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000019"), BaseQuantity = 400, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000025"), BaseQuantity = 150, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000043"), BaseQuantity = 2, Unit = Unit.Teaspoon },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000017"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), BaseQuantity = 300, Unit = Unit.Gram },

                // 8 Wrap thon avocat
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000005"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), BaseQuantity = 160, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000027"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000018"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000039"), BaseQuantity = 1, Unit = Unit.Piece },

                // 9 Salade pois chiches
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000014"), BaseQuantity = 400, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000018"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000039"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000041"), BaseQuantity = 1, Unit = Unit.Teaspoon },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 10 Riz sauté aux œufs
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), BaseQuantity = 250, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000011"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000021"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000023"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000038"), BaseQuantity = 30, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 11 Poulet paprika & poivrons
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000007"), BaseQuantity = 450, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000023"), BaseQuantity = 2, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000019"), BaseQuantity = 300, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000042"), BaseQuantity = 2, Unit = Unit.Teaspoon },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 12 Bowl saumon quinoa avocat
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000010"), BaseQuantity = 300, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000003"), BaseQuantity = 160, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000027"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000018"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000039"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 13 Gratin PDT mozzarella
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000028"), BaseQuantity = 1000, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000034"), BaseQuantity = 200, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000031"), BaseQuantity = 200, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000017"), BaseQuantity = 2, Unit = Unit.Piece },

                // 14 Pâtes crème champignons parmesan
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000001"), BaseQuantity = 220, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000024"), BaseQuantity = 250, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000031"), BaseQuantity = 150, Unit = Unit.Milliliter },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000035"), BaseQuantity = 40, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 15, Unit = Unit.Milliliter },

                // 15 Taboulé boulgour
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000004"), BaseQuantity = 250, Unit = Unit.Gram },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000018"), BaseQuantity = 3, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000026"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000016"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000039"), BaseQuantity = 1, Unit = Unit.Piece },
                new RecipeIngredient { RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), IngredientId = Guid.Parse("b0000000-0000-0000-0000-000000000036"), BaseQuantity = 30, Unit = Unit.Milliliter }
            );
        }
    }
}
