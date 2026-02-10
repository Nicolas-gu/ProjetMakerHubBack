using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Services;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController(IngredientService _ingredientService) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [EndpointDescription("Add a new ingredient.")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddIngredient([FromBody] IngredientCreateDTO dto)
        {
            try
            {
                Ingredient i = await _ingredientService.CreateAsync(dto);
                return Created();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
