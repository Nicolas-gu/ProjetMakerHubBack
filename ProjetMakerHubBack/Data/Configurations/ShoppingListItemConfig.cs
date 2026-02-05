using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class ShoppingListItemConfig : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            builder.HasKey(sli => sli.Id);

            builder.HasOne(sli => sli.ShoppingList)
                .WithMany(sl => sl.ShoppingListItems)
                .HasForeignKey(sli => sli.ShoppingListId);

            builder.HasOne(sli => sli.Ingredient)
                .WithMany(i => i.ShoppingListItems)
                .HasForeignKey(sli => sli.IngredientId);

        }
    }
}
