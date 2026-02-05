using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.SearchName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(t => t.Recipes)
                .WithMany(r => r.Tags);
        }
    }
}
