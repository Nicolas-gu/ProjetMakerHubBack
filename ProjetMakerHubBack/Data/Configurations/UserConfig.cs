using ProjetMakerHubBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasIndex(u  => u.Email).IsUnique();

            builder.Property(u => u.PasswordHash).IsRequired();

            builder.Property(u => u.DisplayName)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasMany(u => u.UserRecipes)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            builder.HasMany(u => u.Recipes)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.CreatedByUserId);

            builder.HasMany(u => u.Plans)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.PantryItems)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.ShoppingLists)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

        }
    }
}
