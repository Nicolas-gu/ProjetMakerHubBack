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
    public class RecipeController(RecipeService _recipeService) : ControllerBase
    {
        [HttpPost]
        [Authorize]
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


        //TODO delete all recette par admin ok mais user doit pouvoir delete ses propres recette
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [EndpointDescription("Delete a recipe.")]

        public async Task<IActionResult> DeleteRecipe([FromRoute] Guid id)
        {
            try
            {
                await _recipeService.DeleteAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Authorize]
        [EndpointDescription("Search a recipe.")]

        public async Task<IActionResult> SearchRecipe([FromQuery]RecipeSearchRequestDto dto)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var result = await _recipeService.SearchAsync(dto, userId);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
