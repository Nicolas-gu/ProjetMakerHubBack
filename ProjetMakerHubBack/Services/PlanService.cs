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
            weekStart = weekStart.ToWeekStartMonday();  // Normalise au lundi de la semaine

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
            weekStart = weekStart.ToWeekStartMonday();   // Normalise au lundi de la semaine
            if (dto.Date < weekStart || dto.Date > weekStart.AddDays(6))
                throw new ArgumentException("Date must be within the selected week.");
            
            var recipe = await _db.Recipes  // Vérifie si recette existe et est accessible
                .AsNoTracking()
                .FirstOrDefaultAsync(r =>
                    r.Id == dto.RecipeId && (r.IsPublic || r.CreatedByUserId == userId));
            if (recipe == null)
                throw new KeyNotFoundException("Recipe not found.");
            var portion = dto.Portion > 0 ? dto.Portion : recipe!.BasePortion;  // portion choisie sinon portion de base
    
            var plan = await _db.Plans  // Récupère le planning de la semaine
                .FirstOrDefaultAsync(p => p.UserId == userId && p.WeekStartDate == weekStart);
            if(plan == null)   
            {
                plan = new Plan    // crée si pas existant
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    WeekStartDate = weekStart,
                    CreatedAt = DateTime.UtcNow,
                };
                _db.Plans.Add(plan);
            }
            var existing = await _db.PlanSlots  // verifie si slot existe deja ( jour + type ) 
                .FirstOrDefaultAsync(s => s.PlanId == plan.Id && s.Date == dto.Date && s.Type == dto.Type);   
            if (existing == null)   // crée si pas existant
            {
                var slot = new PlanSlot
                {
                    Id = Guid.NewGuid(),
                    PlanId = plan.Id,
                    Date = dto.Date,
                    Type = dto.Type,
                    RecipeId = dto.RecipeId,
                    Portion = portion
                };
                _db.PlanSlots.Add(slot);
            }else                   // sinon modifie
            {
                existing.RecipeId = dto.RecipeId;
                existing.Portion = portion;
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
