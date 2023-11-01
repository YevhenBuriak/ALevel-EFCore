using EFCore1.Context;
using EFCore1.Models;
using EFCore1.Repository;

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

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            var repo = new UsersRepository(_dbcontext);
            await repo.Insert(user);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            var repo = new UsersRepository(_dbcontext);
            await repo.Update(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var repo = new UsersRepository(_dbcontext);
            await repo.Delete(id);

            return Ok();
        }
    }
}
