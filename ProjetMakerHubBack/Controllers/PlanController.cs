using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Services;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlanController(PlanService _planService) : ControllerBase
    {
        [HttpGet("{weekStart}")]
        public async Task<IActionResult> GetWeek([FromRoute] DateOnly weekStart)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var planWeek = await _planService.GetPlanWeekAsync(userId, weekStart);
                return Ok(planWeek);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{weekStart}/slots")]
        public async Task<IActionResult> AddSlot([FromRoute] DateOnly weekStart, [FromBody] PlanSlotAddDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                await _planService.AddSlotAsync(userId, weekStart, dto);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{weekStart}/slots/{slotId:guid}")]
        public async Task<IActionResult> DeleteSlot([FromRoute] DateOnly weekStart, [FromRoute] Guid slotId)
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(sub, out var userId)) return Unauthorized();

            await _planService.DeleteSlotAsync(userId, weekStart, slotId);
            return NoContent();
        }
    }
}
