using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class PlanService(AppDbContext _db)
    {
        public async Task<PlanWeekDto> GetPlanWeekAsync(Guid userId, DateOnly weekStart)
        {
            // pour selectionner le lundi de la semaine
            weekStart = weekStart.ToWeekStartMonday();
            //weekStart = DateOnlyExtensions.ToWeekStartMonday(weekStart);
              
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

        public async Task UpsertSlotAsync(Guid userId, DateOnly weekStart, PlanSlotAddDto dto)
        {
            // pour selectionner le lundi de la semaine
            weekStart = weekStart.ToWeekStartMonday();


            if (dto.Date < weekStart || dto.Date > weekStart.AddDays(6))
            {
                throw new ArgumentException("Date must be within the selected week.");
            }

            var recipe = await _db.Recipes
                .AsNoTracking()
                .FirstOrDefaultAsync(r =>
                    r.Id == dto.RecipeId && (r.IsPublic || r.CreatedByUserId == userId));

            var portion = dto.Portion > 0 ? dto.Portion : recipe!.BasePortion;
            
            if (recipe == null)
                throw new KeyNotFoundException("Recipe not found.");

            // Get un planning
            var plan = await _db.Plans
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
                };
                _db.Plans.Add(plan);
                await _db.SaveChangesAsync();
            }
            // verifie si slot existe deja
            var existing = await _db.PlanSlots
                .FirstOrDefaultAsync(s => s.PlanId == plan.Id && s.Date == dto.Date && s.Type == dto.Type);
            // crée si pas existant
            if (existing == null)
            {
                var slot = new PlanSlot
                {
                    Id = Guid.NewGuid(),
                    PlanId = plan.Id,
                    Date = dto.Date,
                    Type = dto.Type,
                    RecipeId = dto.RecipeId,
                    Portion = dto.Portion
                };
                _db.PlanSlots.Add(slot);
            }
            else // ou le modifie
            {
                existing.RecipeId = dto.RecipeId;
                existing.Portion = dto.Portion;
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteSlotAsync(Guid userId, Guid slotId)
        {
            var slot = await _db.PlanSlots
                .Include(s => s.Plan)
                .FirstOrDefaultAsync(s => s.Id == slotId && s.Plan.UserId == userId);

            if (slot == null)
            {
                throw new KeyNotFoundException("Slot not found.");
            }

            _db.PlanSlots.Remove(slot);
            await _db.SaveChangesAsync();
        }
    }
}
