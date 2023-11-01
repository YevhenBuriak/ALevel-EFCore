using EFCore1.Context;
using EFCore1.Models;

using Microsoft.EntityFrameworkCore;

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

        public async Task InsertOneToOne(int userId, UserSettings settings)
        {
            // Option 1: find, update
            var existingUser = await _dbContext.Users.FindAsync(userId);
            if (existingUser == null) return;

            existingUser.UserSettings = settings;
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task InsertManyToMany(int userId, ICollection<Blog> blogs)
        {
            // Option 1: find, update
            var existingUser = await _dbContext.Users.FindAsync(userId);
            if (existingUser == null) return;

            //existingUser.BlogSubscribsions = blogs;
            _ = await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
           return await _dbContext.Users.ToListAsync();
        }
    }
}
