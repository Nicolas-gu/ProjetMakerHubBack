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
            var plan = await _db.Plans
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


            await _db.SaveChangesAsync();
        }
    }
}
