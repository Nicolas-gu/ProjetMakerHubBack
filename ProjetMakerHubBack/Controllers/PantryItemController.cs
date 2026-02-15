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
    public class PantryItemController(PantryService _pantryService) : ControllerBase
    {
        [HttpGet]
        [EndpointDescription("Get list of ingredients in pantry.")]
        public async Task<IActionResult> GetPantryItem()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var result = await _pantryService.GetAsync(userId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EndpointDescription("Add or update ingredient in pantry.")]
        public async Task<IActionResult> AddPantryItem([FromBody] PantryUpdateDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var result = await _pantryService.UpsertAsync(userId, dto);

                if(result == null)
                {
                    return NoContent();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ingredientId:guid}")]
        [EndpointDescription("Delete ingredient from pantry.")]
        public async Task<IActionResult> Delete([FromRoute] Guid ingredientId)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                await _pantryService.DeleteAsync(userId, ingredientId);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
