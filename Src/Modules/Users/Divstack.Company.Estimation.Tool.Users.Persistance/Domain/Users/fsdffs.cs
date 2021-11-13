namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class fsdffs : IEntityTypeConfiguration<IdentityUserLogin<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
    {
        builder.Property(m => m.LoginProvider).HasMaxLength(85);
        builder.Property(m => m.ProviderKey).HasMaxLength(85);
    }
}
