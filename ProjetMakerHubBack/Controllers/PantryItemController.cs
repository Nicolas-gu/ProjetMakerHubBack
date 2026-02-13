using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PantryItemController : ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetPantryItem()
        //{
        //    try
        //    {
        //        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
