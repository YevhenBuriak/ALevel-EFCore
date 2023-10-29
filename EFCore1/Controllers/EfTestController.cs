using EFCore1.Context;

using Microsoft.AspNetCore.Mvc;

namespace EFCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfTestController : ControllerBase
    {
        private readonly EFCoreContext _dbcontext;

        public EfTestController(EFCoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult> TestConnection()
        {
            if (_dbcontext.Database.CanConnect())
            {
                return Ok(_dbcontext.Database.ProviderName);
            }

            return BadRequest();
        }
    }
}
