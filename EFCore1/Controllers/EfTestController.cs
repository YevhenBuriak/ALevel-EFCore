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
        private readonly EFCoreContext _dbContext;

        public EfTestController(EFCoreContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet("connection-test")]
        public async Task<ActionResult> TestConnection()
        {
            if (_dbContext.Database.CanConnect())
            {
                return Ok(_dbContext.Database.ProviderName);
            }

            return BadRequest();
        }

        [HttpGet("change-tracker-test")]
        public async Task<ActionResult> TestChangeTracking()
        {
            // 1. Change tracker
            _ = _dbContext.ChangeTracker;

            // 2. Track entity
            _dbContext.Attach(new User { Id = 1 });

            // 4. On retrieve (need to have at least 2 users in db =))
            var users = await _dbContext.Users.ToListAsync();

            // 5. Change
            users.First().Name = "Change tracked";

            // 6. Detach one
            _dbContext.Entry(users.Last()).State = EntityState.Detached;
            
            // 6. Detach all
            _dbContext.ChangeTracker.Clear();

            // 7. As no tracking
            var deatachedUsers = await _dbContext.Users.AsNoTracking().ToListAsync();

            return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            var repo = new UsersRepository(_dbContext);
            await repo.Insert(user);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            var repo = new UsersRepository(_dbContext);
            await repo.Update(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var repo = new UsersRepository(_dbContext);
            await repo.Delete(id);

            return Ok();
        }
    }
}
