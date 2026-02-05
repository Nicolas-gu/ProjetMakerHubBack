using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Data.Configurations
{
    public class PlanSlotConfig : IEntityTypeConfiguration<PlanSlot>
    {
        public void Configure(EntityTypeBuilder<PlanSlot> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.Plan)
                .WithMany(p => p.Slots)
                .HasForeignKey(ps => ps.PlanId);

            builder.HasOne(ps => ps.Recipe)
                .WithMany(r => r.PlanSlots)
                .HasForeignKey(ps => ps.RecipeId);
        }
    }
}
