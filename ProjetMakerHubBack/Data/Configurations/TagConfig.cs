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

        //    builder.HasData(
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Végétarien", SearchName = "vegetarien" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Name = "Vegan", SearchName = "vegan" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Name = "Sans gluten", SearchName = "sansgluten" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), Name = "Sans lactose", SearchName = "sanslactose" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111115"), Name = "Healthy", SearchName = "healthy" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111116"), Name = "Protéiné", SearchName = "proteine" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111117"), Name = "Rapide", SearchName = "rapide" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111118"), Name = "Facile", SearchName = "facile" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111119"), Name = "Express", SearchName = "express" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111120"), Name = "Batch cooking", SearchName = "batchcooking" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111121"), Name = "Entrée", SearchName = "entree" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111122"), Name = "Plat principal", SearchName = "platprincipal" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111123"), Name = "Dessert", SearchName = "dessert" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111124"), Name = "Petit-déjeuner", SearchName = "petitdejeuner" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111125"), Name = "Apéritif", SearchName = "aperitif" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111126"), Name = "Italien", SearchName = "italien" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111127"), Name = "Asiatique", SearchName = "asiatique" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111128"), Name = "Mexicain", SearchName = "mexicain" },
        //    new Tag { Id = Guid.Parse("11111111-1111-1111-1111-111111111129"), Name = "Traditionnel", SearchName = "traditionnel" }
        //);
        }
    }
}
