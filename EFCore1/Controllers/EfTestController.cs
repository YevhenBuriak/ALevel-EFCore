using EFCore1.Context;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore1.Controllers
{
    [Route("api/showcase")]
    [ApiController]
    public class EfTestController : ControllerBase
    {
        private readonly EFCoreContext _dbcontext;

        public EfTestController(EFCoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("connection-test")]
        public async Task<ActionResult> TestConnection()
        {
            if (_dbcontext.Database.CanConnect())
            {
                return Ok(_dbcontext.Database.ProviderName);
            }

            return BadRequest();
        }

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _dbcontext.Users.ToListAsync();

            return Ok(users);
        }
    }
}
