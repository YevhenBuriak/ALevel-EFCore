using EFCore1.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore1.Context;

public class EFCoreContext : DbContext
{
    public DbSet<User> Users { get; private set; }

    public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();
        modelBuilder.Entity<User>().Property(b => b.Surname).IsRequired();

        modelBuilder.Entity<User>().Property(x => x.Birthday)
            .HasConversion(new ValueConverter<DateOnly?, DateTime?>(
                x => x.HasValue ? x.Value.ToDateTime(TimeOnly.MinValue) : null,
                y => y.HasValue ? DateOnly.FromDateTime(y.Value) : null)
            );
    }
}
