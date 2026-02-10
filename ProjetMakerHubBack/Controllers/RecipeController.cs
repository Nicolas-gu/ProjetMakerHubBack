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
        public async Task<IActionResult> AddRecipe([FromBody]RecipeCreateDTO dto)
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


        //[HttpGet]
        //[Authorize]
        //[EndpointDescription("Search a recipe.")]

        //public async Task<IActionResult> GetRecipe()
        //{
        //    //TODO creer methode search ds le service
        //    return Ok();
        //}


    }
}
