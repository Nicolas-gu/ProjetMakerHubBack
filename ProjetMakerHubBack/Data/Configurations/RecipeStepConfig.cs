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
                // 1
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000001"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 1, StepInstruction = "Émincer oignon et ail." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000002"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 2, StepInstruction = "Les faire revenir dans l’huile d’olive 3 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000003"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 3, StepInstruction = "Ajouter tomates concassées + concentré, assaisonner." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000004"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 4, StepInstruction = "Mijoter 12–15 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000005"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000001"), StepNumber = 5, StepInstruction = "Cuire les pâtes, mélanger avec la sauce et servir." },

                // 2
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000006"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 1, StepInstruction = "Émincer oignon et ail, couper le poivron en dés." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000007"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 2, StepInstruction = "Faire revenir oignon/ail dans l’huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000008"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 3, StepInstruction = "Ajouter le poivron puis tomates + épices." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000009"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 4, StepInstruction = "Mijoter 10 minutes, ajouter les haricots rouges." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000010"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000002"), StepNumber = 5, StepInstruction = "Mijoter encore 8 minutes et servir." },

                // 3
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000011"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 1, StepInstruction = "Cuire le quinoa, puis le laisser tiédir." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000012"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 2, StepInstruction = "Couper concombre et tomate en dés." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000013"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 3, StepInstruction = "Émietter la feta." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000014"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 4, StepInstruction = "Assaisonner avec citron + huile d’olive." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000015"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000003"), StepNumber = 5, StepInstruction = "Mélanger, reposer 10 minutes et servir." },

                // 4
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000016"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 1, StepInstruction = "Émincer oignon, couper champignons." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000017"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 2, StepInstruction = "Faire revenir oignon + champignons." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000018"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 3, StepInstruction = "Ajouter épinards 2 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000019"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 4, StepInstruction = "Battre les œufs et verser sur la garniture." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000020"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000004"), StepNumber = 5, StepInstruction = "Cuire à feu doux, plier et servir." },

                // 5
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000021"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 1, StepInstruction = "Cuire le riz." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000022"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 2, StepInstruction = "Saisir le poulet dans l’huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000023"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 3, StepInstruction = "Ajouter soja + miel + citron." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000024"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 4, StepInstruction = "Laisser réduire 4–5 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000025"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000005"), StepNumber = 5, StepInstruction = "Servir sur le riz." },

                // 6
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000026"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 1, StepInstruction = "Faire revenir oignon et ail dans l’huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000027"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 2, StepInstruction = "Ajouter le bœuf haché et le faire dorer." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000028"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 3, StepInstruction = "Ajouter tomates + concentré, assaisonner." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000029"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 4, StepInstruction = "Mijoter 25–30 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000030"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000006"), StepNumber = 5, StepInstruction = "Cuire les pâtes et servir avec la sauce." },

                // 7
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000031"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), StepNumber = 1, StepInstruction = "Faire revenir oignon et ail dans l’huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000032"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), StepNumber = 2, StepInstruction = "Ajouter curry et mélanger 30 secondes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000033"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), StepNumber = 3, StepInstruction = "Ajouter lentilles + tomates, cuire 20 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000034"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), StepNumber = 4, StepInstruction = "Ajouter épinards 2–3 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000035"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000007"), StepNumber = 5, StepInstruction = "Servir avec riz." },

                // 8
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000036"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), StepNumber = 1, StepInstruction = "Égoutter le thon." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000037"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), StepNumber = 2, StepInstruction = "Écraser l’avocat avec le citron." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000038"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), StepNumber = 3, StepInstruction = "Couper tomate et concombre." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000039"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), StepNumber = 4, StepInstruction = "Garnir la tortilla et rouler." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000040"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000008"), StepNumber = 5, StepInstruction = "Couper et servir." },

                // 9
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000041"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), StepNumber = 1, StepInstruction = "Rincer les pois chiches." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000042"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), StepNumber = 2, StepInstruction = "Couper tomate, concombre et oignon." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000043"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), StepNumber = 3, StepInstruction = "Assaisonner citron + huile + cumin." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000044"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), StepNumber = 4, StepInstruction = "Mélanger et reposer 10 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000045"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000009"), StepNumber = 5, StepInstruction = "Servir frais." },

                // 10
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000046"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), StepNumber = 1, StepInstruction = "Faire revenir les légumes dans l’huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000047"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), StepNumber = 2, StepInstruction = "Brouiller les œufs dans la poêle." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000048"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), StepNumber = 3, StepInstruction = "Ajouter le riz et mélanger." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000049"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), StepNumber = 4, StepInstruction = "Ajouter sauce soja et faire sauter 2–3 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000050"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000010"), StepNumber = 5, StepInstruction = "Servir chaud." },

                // 11
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000051"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), StepNumber = 1, StepInstruction = "Dorer le poulet dans l’huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000052"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), StepNumber = 2, StepInstruction = "Ajouter oignon puis poivrons." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000053"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), StepNumber = 3, StepInstruction = "Ajouter paprika + tomates concassées." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000054"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), StepNumber = 4, StepInstruction = "Mijoter 10–12 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000055"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000011"), StepNumber = 5, StepInstruction = "Rectifier l’assaisonnement et servir." },

                // 12
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000056"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), StepNumber = 1, StepInstruction = "Cuire le quinoa." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000057"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), StepNumber = 2, StepInstruction = "Cuire le saumon à la poêle." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000058"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), StepNumber = 3, StepInstruction = "Couper avocat, concombre et tomate." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000059"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), StepNumber = 4, StepInstruction = "Assaisonner citron + huile." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000060"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000012"), StepNumber = 5, StepInstruction = "Composer les bols et servir." },

                // 13
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000061"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), StepNumber = 1, StepInstruction = "Préchauffer le four à 190°C." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000062"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), StepNumber = 2, StepInstruction = "Éplucher et trancher les pommes de terre." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000063"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), StepNumber = 3, StepInstruction = "Mettre dans un plat avec ail et crème." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000064"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), StepNumber = 4, StepInstruction = "Cuire 35 minutes couvert." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000065"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000013"), StepNumber = 5, StepInstruction = "Ajouter mozzarella et gratiner 10 minutes." },

                // 14
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000066"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), StepNumber = 1, StepInstruction = "Cuire les pâtes al dente." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000067"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), StepNumber = 2, StepInstruction = "Faire revenir oignon + champignons." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000068"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), StepNumber = 3, StepInstruction = "Ajouter la crème et chauffer 2–3 minutes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000069"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), StepNumber = 4, StepInstruction = "Ajouter le parmesan et mélanger." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000070"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000014"), StepNumber = 5, StepInstruction = "Ajouter les pâtes, mélanger et servir." },

                // 15
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000071"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), StepNumber = 1, StepInstruction = "Préparer le boulgour (réhydratation/cuisson selon paquet)." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000072"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), StepNumber = 2, StepInstruction = "Couper tomates, concombre et oignon." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000073"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), StepNumber = 3, StepInstruction = "Assaisonner citron + huile d’olive." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000074"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), StepNumber = 4, StepInstruction = "Mélanger boulgour + légumes." },
                new RecipeStep { Id = Guid.Parse("d0000000-0000-0000-0000-000000000075"), RecipeId = Guid.Parse("c0000000-0000-0000-0000-000000000015"), StepNumber = 5, StepInstruction = "Laisser 20–30 minutes au frais et servir." }
            );
        }
    }
}
