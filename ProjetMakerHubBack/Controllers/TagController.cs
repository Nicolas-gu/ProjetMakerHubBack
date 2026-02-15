using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Services;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TagController(TagService _tagService) : ControllerBase
    {
        [HttpGet]
        [EndpointDescription("Get list of tags.")]

        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var tags = await _tagService.GetAllAsync();
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EndpointDescription("Add a new tag (Admin only).")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTag([FromBody] TagCreateDto dto)
        {
            try
            {
                await _tagService.CreateAsync(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{tagId:guid}")]
        [EndpointDescription("Delete a tag (Admin only).")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTag([FromRoute] Guid tagId)
        {
            try
            {
                await _tagService.DeleteAsync(tagId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
