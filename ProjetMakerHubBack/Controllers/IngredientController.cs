using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Services;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IngredientController(IngredientService _ingredientService) : ControllerBase
    {
        [HttpGet]
        [EndpointDescription("Search an ingredient.")]
        public async Task<IActionResult> SearchIngredient([FromQuery] IngredientSearchRequestDto dto)
        {
            try
            {
                var result = await _ingredientService.SearchAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EndpointDescription("Add a new ingredient.")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddIngredient([FromBody] IngredientCreateDto dto)
        {
            try
            {
                var created = await _ingredientService.CreateAsync(dto);

                return CreatedAtAction(
                    nameof(SearchIngredient),
                    new { q = created.Name },
                    new IngredientSearchResponseDto { Id = created.Id, Name = created.Name }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ingredientId}")]
        [Authorize(Roles = "Admin")]
        [EndpointDescription("Delete an ingredient(admin only).")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] Guid ingredientId)
        {
            try
            {
                await _ingredientService.DeleteAsync(ingredientId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

