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

        modelBuilder.Entity<User>()
            .HasOne(x => x.UserSettings)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<User>().HasMany(x => x.Articles).WithMany(x => x.Athors);
        modelBuilder.Entity<User>().HasMany(x => x.BlogSubscribsions).WithMany(x => x.Readers);

        // ------------- User settings

        modelBuilder.Entity<UserSettings>().Property(x => x.Theme)
            .HasConversion(
                v => v.ToString(),
                v => (ThemeSetting)Enum.Parse(typeof(ThemeSetting), v)
            );
        modelBuilder.Entity<UserSettings>()
            .HasOne(x => x.User)
            .WithOne(x => x.UserSettings)
            .OnDelete(DeleteBehavior.Cascade);

        // ------------- Blog

        modelBuilder.Entity<Blog>().HasMany(x => x.Articles).WithOne(x => x.Blog);
        modelBuilder.Entity<Blog>().HasMany(x => x.Readers).WithMany(x => x.BlogSubscribsions);

        // ------------- Article

        modelBuilder.Entity<Article>().HasOne(x => x.Blog).WithMany(x => x.Articles);
        modelBuilder.Entity<Article>().HasMany(x => x.Athors).WithMany(x => x.Articles);
    }
}
