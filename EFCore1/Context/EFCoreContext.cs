using EFCore1.Models;

using Microsoft.EntityFrameworkCore;

namespace EFCore1.Context;

public class EFCoreContext : DbContext
{
    public DbSet<User> Users { get; private set; }
    public DbSet<UserSettings> UserSettings { get; private set; }

    public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Option 1
        //modelBuilder.ApplyConfiguration(new UserConfiguration());

        // Option 2
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
        
}
