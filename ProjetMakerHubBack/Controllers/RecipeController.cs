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
    public class RecipeController(RecipeService _recipeService) : ControllerBase
    {
        [HttpGet]
        [EndpointDescription("Search a recipe.")]
        public async Task<IActionResult> SearchRecipe([FromQuery]RecipeSearchRequestDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _recipeService.SearchAsync(dto, userId);

            return Ok(result);
        }

        [HttpPost]
        [EndpointDescription("Add a new recipe.")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddRecipe([FromBody]RecipeCreateDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                Recipe r = await _recipeService.CreateAsync(dto, userId);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{recipeId:guid}")]
        [EndpointDescription("Get a recipe by id.")]
        public async Task<IActionResult> GetRecipeById([FromRoute] Guid recipeId)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var result = await _recipeService.GetByIdAsync(recipeId, userId);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{recipeId:guid}")]
        [EndpointDescription("Update a recipe.")]
        public async Task<IActionResult> UpdateRecipe([FromRoute] Guid recipeId, [FromBody] RecipeUpdateDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var role = User.FindFirstValue(ClaimTypes.Role);

                await _recipeService.UpdateAsync(recipeId, dto, userId, role);
                
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{recipeId:guid}")]
        [EndpointDescription("Delete a recipe.")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] Guid recipeId)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var role = User.FindFirstValue(ClaimTypes.Role);

                await _recipeService.DeleteAsync(recipeId, userId, role!);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{recipeId:guid}/favorite")]
        [EndpointDescription("Add a recipe to favorites.")]
        public async Task<IActionResult> AddFavorite([FromRoute] Guid recipeId)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                await _recipeService.SetFavoriteAsync(userId, recipeId, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{recipeId:guid}/favorite")]
        [EndpointDescription("Remove a recipe to favorites.")]
        public async Task<IActionResult> RemoveFavorite([FromRoute] Guid recipeId)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                await _recipeService.SetFavoriteAsync(userId, recipeId, false);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
