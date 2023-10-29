using EFCore1.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IntroConsoleEF.Context;
internal class EFCoreDbContextFactory : IDesignTimeDbContextFactory<EFCoreContext>
{
    private static string? _connectionString;

    public EFCoreContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public EFCoreContext CreateDbContext(string[] args)
    {
        if (string.IsNullOrEmpty(_connectionString))
        {
            LoadConnectionString();
        }

        var builder = new DbContextOptionsBuilder<EFCoreContext>();
        builder.UseSqlServer(_connectionString);

        return new EFCoreContext(builder.Options);
    }

    private static void LoadConnectionString()
    {
        var builder = new ConfigurationBuilder();
        builder
            .AddJsonFile("appsettings.json", optional: false)
            .AddUserSecrets<EFCoreDbContextFactory>();

        var configuration = builder.Build();

        _connectionString = configuration.GetConnectionString(nameof(EFCoreContext));
    }
}
