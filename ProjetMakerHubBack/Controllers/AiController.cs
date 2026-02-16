using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetMakerHubBack.API.Dto;

namespace ProjetMakerHubBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AiController : ControllerBase
    {
        //[HttpPost("generate")]
        //public async Task<ActionResult<AiRecipeDraftDto>> Generate([FromBody] AiGenerateRecipeRequestDto dto)
        //{
        //    var draft = await _ai.GenerateRecipeAsync(dto);
        //    return Ok(draft);
        //}

        //[HttpPost("import/url")]
        //public async Task<ActionResult<RecipeCreateDto>> ImportUrl([FromBody] AiImportUrlRequestDto dto)
        //{
        //    var draft = await _ai.ImportFromUrlAsync(dto.Url);
        //    return Ok(draft);
        //}

        //[HttpPost("import/image")]
        //[Consumes("multipart/form-data")]
        //[RequestSizeLimit(6_000_000)]
        //public async Task<ActionResult<RecipeCreateDto>> ImportImage([FromForm] IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest(new { error = "File is required." });
        //    }

        //    var draft = await _ai.ImportFromImageAsync(file);
        //    return Ok(draft);
        //}
    }
}
