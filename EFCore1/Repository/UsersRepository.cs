using EFCore1.Context;
using EFCore1.Models;

namespace EFCore1.Repository
{
    public class UsersRepository
    {
        private readonly EFCoreContext _dbContext;

        public UsersRepository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(User user)
        {
            // Option 1: User model is a parameter
            // Option 2: User is being created here with the 'new' keyword

            await _dbContext.Users.AddAsync(user);
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            // Option 1: retrieve, track, update property by property
            //var existingUser = await _dbContext.Users.FindAsync(user.Id);
            //if (existingUser == null) return;

            //existingUser.Name = user.Name;
            //existingUser.Surname = user.Surname;
            //await _dbContext.SaveChangesAsync();

            // Option 2: Full object
            _dbContext.Update(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            // Option 1: retrieve, track, update property by property
            //var existingUser = await _dbContext.Users.FindAsync(id);
            //if (existingUser == null) return;

            //_dbContext.Remove(existingUser);
            //await _dbContext.SaveChangesAsync();

            // Option 2: track as object, remove
            var tacker = new User { Id = id };
            _dbContext.Users.Attach(tacker);
            _dbContext.Remove(tacker);
            await _dbContext.SaveChangesAsync();
        }
    }
}
