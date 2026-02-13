using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class PlanService(AppDbContext _db)
    {
        public async Task<PlanWeekDto> GetPlanWeekAsync(Guid userId, DateOnly weekStart)
        {
            var plan = await _db.Plans.AsNoTracking()
                // trouve le planning de cet utilisateur pour cette semaine
                .Where(p => p.UserId == userId && p.WeekStartDate == weekStart)
                .Select(p => new PlanWeekDto
                {
                    PlanId = p.Id,
                    WeekStartDate = p.WeekStartDate,
                    Slots = p.Slots
                        .OrderBy(s => s.Date)
                        .ThenBy(s => s.Type)
                        .Select(s => new PlanSlotDto
                    {
                        SlotId = s.Id,
                        Date = s.Date,
                        Type = s.Type,
                        Portion = s.Portion,
                        RecipeId = s.RecipeId,
                        RecipeTitle = s.Recipe!.Title,
                        PrepTime = s.Recipe.PrepTime,
                        CookTime = s.Recipe.CookTime
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if(plan == null)
            {
                return new PlanWeekDto
                {
                    PlanId = Guid.Empty,
                    WeekStartDate = weekStart,
                    Slots = new List<PlanSlotDto>()
                };
            }
            return plan;
        }

        public async Task AddSlotAsync(Guid userId, DateOnly weekStart, PlanSlotAddDto dto)
        {
            if(dto.Portion <= 0)
            {
                throw new ArgumentException("Portion must be > 0.");
            }

            if (dto.Date < weekStart || dto.Date > weekStart.AddDays(6))
            {
                throw new ArgumentException("Date must be within the selected week.");
            }

            // verifie si recette est publique ou perso
            var canUse = await _db.Recipes.AnyAsync(r =>
                r.Id == dto.RecipeId && (r.IsPublic || r.CreatedByUserId == userId));
            if (!canUse) throw new KeyNotFoundException("Recipe not found.");

            // Get un planning
            var plan = await _db.Plans
                .Include(p => p.Slots)
                .FirstOrDefaultAsync(p => p.UserId == userId && p.WeekStartDate == weekStart);
            // Ou le crée
            if(plan == null)
            {
                plan = new Plan
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    WeekStartDate = weekStart,
                    CreatedAt = DateTime.UtcNow,
                    Slots = new List<PlanSlot>()
                };
                _db.Plans.Add(plan);
            }

            var existing = plan.Slots.FirstOrDefault(s => s.Date == dto.Date && s.Type == dto.Type);

            if (existing == null)
            {
                plan.Slots.Add(new PlanSlot
                {
                    Id = Guid.NewGuid(),
                    PlanId = plan.Id,
                    Date = dto.Date,
                    Type = dto.Type,
                    RecipeId = dto.RecipeId,
                    Portion = dto.Portion
                });
            }
            else
            {
                existing.RecipeId = dto.RecipeId;
                existing.Portion = dto.Portion;
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteSlotAsync(Guid userId, DateOnly weekStart, Guid slotId)
        {
            var slot = await _db.PlanSlots
                .Include(s => s.Plan)
                .FirstOrDefaultAsync(s => s.Id == slotId
                    && s.Plan.UserId == userId
                    && s.Plan.WeekStartDate == weekStart);

            if (slot == null)
            {
                throw new KeyNotFoundException("Slot not found.");
            }

            _db.PlanSlots.Remove(slot);
            await _db.SaveChangesAsync();
        }
    }
}
