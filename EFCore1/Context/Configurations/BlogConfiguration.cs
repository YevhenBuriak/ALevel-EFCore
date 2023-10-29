using EFCore1.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.Context.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasMany(x => x.Articles).WithOne(x => x.Blog);
        builder.HasMany(x => x.Readers).WithMany(x => x.BlogSubscribsions);
    }
}
