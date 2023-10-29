using EFCore1.Context;

using Microsoft.AspNetCore.Mvc;

namespace EFCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfTestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> TestConnection()
        {
            var dbContext = new EFCoreContext();

            if (dbContext.Database.CanConnect())
            {
                return Ok(dbContext.Database.ProviderName);
            }

            return BadRequest();
        }
    }
}
