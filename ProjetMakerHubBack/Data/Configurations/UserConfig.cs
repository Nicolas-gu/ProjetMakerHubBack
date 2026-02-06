using ProjetMakerHubBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Application.Utils;

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
                .IsRequired(false)
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

            builder.HasData([
                new () { Id = new Guid("da32c7e3-2ff5-4bd0-9b2b-e407cdc36df4"), DisplayName = "Kooz", Email = "kooz@mail.com", PasswordHash = PasswordUtils.Hash("1234", Guid.Parse("1b813899-603a-40cf-a635-c56ef6363ca5")), Role = Domain.Enums.Role.Admin},
                new () { Id = new Guid("62d01393-e0d0-4e0a-ad38-6e8507c4fcc2"), DisplayName = "Usertest", Email = "usertest@mail.com", PasswordHash = PasswordUtils.Hash("1234", Guid.Parse("4988d3e3-2a76-48df-8a8f-d7353ac9811e")), Role = Domain.Enums.Role.User}
            ]);

        }
    }
}
