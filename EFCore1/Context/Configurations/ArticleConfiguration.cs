using EFCore1.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.Context.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        //builder.HasOne(x => x.Blog).WithMany(x => x.Articles);
        //builder.HasMany(x => x.Athors).WithMany(x => x.Articles);
    }
}

