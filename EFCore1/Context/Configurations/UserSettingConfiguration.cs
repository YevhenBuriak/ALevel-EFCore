using EFCore1.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.Context.Configurations;

public class UserSettingConfiguration : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder
            .Property(x => x.Theme)
            .HasConversion(
                v => v.ToString(),
                v => (ThemeSetting)Enum.Parse(typeof(ThemeSetting), v)
            );
        //builder
        //    .HasOne(x => x.User)
        //    .WithOne(x => x.UserSettings)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}
