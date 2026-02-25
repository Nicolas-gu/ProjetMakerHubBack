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
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> SearchRecipe([FromQuery]RecipeSearchRequestDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _recipeService.SearchAsync(dto, userId);

            return Ok(result);
        }

        [HttpPost]
        [EndpointDescription("Add a new recipe.")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddRecipe([FromBody]RecipeCreateDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                Recipe r = await _recipeService.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetRecipeById), new { recipeId = r.Id }, new { id = r.Id }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{recipeId:guid}")]
        [EndpointDescription("Get a recipe by id.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRecipe([FromRoute] Guid recipeId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var role = User.FindFirstValue(ClaimTypes.Role) ?? "";

            try
            {
                await _recipeService.DeleteAsync(recipeId, userId, role);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("{recipeId}/image")]
        [EndpointDescription("Add an image to recipe.")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UploadImg(Guid recipeId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "File is required." });
            }

            var allowed = new[] { "image/jpeg", "image/png", "image/webp" };
            if (!allowed.Contains(file.ContentType))
            {
                return BadRequest(new { error = "Only jpg/png/webp allowed." });
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var role = User.FindFirstValue(ClaimTypes.Role);

            var imageUrl = await _recipeService.UploadImgAsync(recipeId, userId, role, file);

            return Ok(new { imageUrl });
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
