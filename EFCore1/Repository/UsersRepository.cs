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
    }
}
