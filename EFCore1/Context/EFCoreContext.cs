using Microsoft.EntityFrameworkCore;

namespace EFCore1.Context;

public class EFCoreContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString =
            "Data Source=localhost;Initial Catalog = master;user id=sa;password=passwordX123;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        optionsBuilder.UseSqlServer(connectionString);
    }
}
