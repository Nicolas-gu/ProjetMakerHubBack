using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class RecipeStepConfig : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure(EntityTypeBuilder<RecipeStep> builder)
        {
            builder.HasKey(rs => rs.Id);

            builder.HasOne(rs => rs.Recipe)
                .WithMany(r => r.RecipeSteps)
                .HasForeignKey(rs => rs.RecipeId);

            builder.HasData(
                // Pâtes pesto
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000001"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 1, StepInstruction = "Cuire les pâtes dans l'eau salée." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000002"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 2, StepInstruction = "Égoutter, ajouter le pesto et mélanger." },

                // Riz sauté poulet
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000003"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 1, StepInstruction = "Faire revenir oignon et ail dans l'huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000004"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 2, StepInstruction = "Ajouter le poulet, cuire puis ajouter le riz et assaisonner." },

                // Omelette
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000005"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 1, StepInstruction = "Battre les œufs avec sel et poivre." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000006"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 2, StepInstruction = "Cuire les champignons, ajouter les œufs et le fromage." },

                // Salade thon
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000007"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 1, StepInstruction = "Mélanger salade, thon et maïs." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000008"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 2, StepInstruction = "Assaisonner avec citron, huile d'olive, sel et poivre." },

                // Chili
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000009"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 1, StepInstruction = "Faire revenir oignon et poivron." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000010"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 2, StepInstruction = "Ajouter sauce tomate, haricots, maïs et épices, mijoter." },

                // Poulet miel-citron
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000011"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 1, StepInstruction = "Faire dorer le poulet dans un peu d'huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000012"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 2, StepInstruction = "Ajouter miel + citron, laisser réduire et assaisonner." }
            );
        }
    }
}
