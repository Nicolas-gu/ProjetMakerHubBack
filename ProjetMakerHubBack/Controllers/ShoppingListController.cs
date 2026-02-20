using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Services;
using ProjetMakerHubBack.Domain.Entities;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShoppingListController(ShoppingListService _shoppingService) : ControllerBase
    {
        [HttpGet]
        [EndpointDescription("Get shopping list for a week.")]
        public async Task<ActionResult<ShoppingListDto>> GetShoppingList([FromQuery] DateOnly weekStart)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _shoppingService.GetAsync(userId, weekStart);

            if (result == null)
                return NotFound("Shopping list not found for this week.");

            return Ok(result);
        }


        [HttpPost("{weekStart}/generate")]
        [EndpointDescription("Generate a shopping list.")]
        public async Task<IActionResult> Generate([FromRoute]DateOnly weekStart)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var results = await _shoppingService.GenerateAsync(userId, weekStart);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{weekStart}/items")]
        public async Task<IActionResult> AddItem([FromRoute] DateOnly weekStart, [FromBody] ShoppingListItemCreateDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var result = await _shoppingService.AddAsync(userId, weekStart, dto);
                
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("items/{itemId:guid}")]
        [EndpointDescription("Update item from shopping list.")]
        public async Task<IActionResult> PatchItem([FromRoute] Guid itemId, [FromBody] ShoppingListItemUpdateDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                await _shoppingService.UpdateItemAsync(userId, itemId, dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("items/{itemId:guid}")]
        [EndpointDescription("Delete item from shopping list.")]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid itemId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _shoppingService.DeleteItemAsync(userId, itemId);
            return NoContent();
        }
    }
}
