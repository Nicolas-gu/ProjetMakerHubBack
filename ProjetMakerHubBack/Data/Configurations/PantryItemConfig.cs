using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class PantryItemConfig : IEntityTypeConfiguration<PantryItem>
    {
        public void Configure(EntityTypeBuilder<PantryItem> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.HasOne(pi => pi.User)
                .WithMany(u => u.PantryItems)
                .HasForeignKey(pi => pi.UserId);

            builder.HasOne(pi => pi.Ingredient)
                .WithMany(i => i.PantryItems)
                .HasForeignKey(pi => pi.IngredientId);

        }
    }
}
