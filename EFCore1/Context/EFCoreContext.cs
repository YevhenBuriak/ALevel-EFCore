using Microsoft.EntityFrameworkCore;

namespace EFCore1.Context;

public class EFCoreContext: DbContext
{
    public EFCoreContext()
    {
    }

    public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
    {
    }
}
