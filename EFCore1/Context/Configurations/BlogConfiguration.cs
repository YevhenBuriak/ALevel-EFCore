using Azure;

using EFCore1.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;

namespace EFCore1.Context.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasMany(x => x.Articles).WithOne(x => x.Blog);
        builder
            .HasMany(x => x.Readers)
            .WithMany(x => x.BlogSubscribsions)
            .UsingEntity(
                l => l.HasOne(typeof(User)).WithMany().HasForeignKey("ReadersId"),
                r => r.HasOne(typeof(Blog)).WithMany().HasForeignKey("BlogSubscribsionsId"));
    }
}
