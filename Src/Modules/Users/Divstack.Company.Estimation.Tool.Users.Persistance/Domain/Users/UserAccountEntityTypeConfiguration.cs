using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

internal class UserAccountEntityTypeConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.Property(userAccount => userAccount.Id).HasMaxLength(85);
        builder.Property(userAccount => userAccount.PublicId).IsRequired();
        builder.OwnsMany<FailedLoginAttempt>("FailedLoginAttempts", ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToTable("FailedLoginAttempts");
            ownedNavigationBuilder.WithOwner("UserAccount").HasForeignKey("UserId");
            ownedNavigationBuilder.HasKey("Id");
            ownedNavigationBuilder.Property("LoginDate").IsRequired();
        });

        builder.OwnsMany<PasswordHistory>("ArchivedPasswords", ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToTable("PasswordHistory");
            ownedNavigationBuilder.WithOwner("UserAccount");
            ownedNavigationBuilder.HasKey("Id");
        });

        builder.HasKey("Id");
        builder.Property(user => user.PasswordExpirationDate).IsRequired(false);
        builder.Property("LastLoginDate").IsRequired(false);
    }
}

internal class UserAccfsfountEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        builder.Property(m => m.Id).HasMaxLength(85);
    }
}

internal class fs : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        builder.Property(m => m.Id).HasMaxLength(85);
    }
}

internal class fsdffs : IEntityTypeConfiguration<IdentityUserLogin<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
    {
        builder.Property(m => m.LoginProvider).HasMaxLength(85);
        builder.Property(m => m.ProviderKey).HasMaxLength(85);
    }
}

internal class fsdffsdffs : IEntityTypeConfiguration<IdentityUserToken<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
    {
        builder.Property(m => m.LoginProvider).HasMaxLength(85);
        builder.Property(m => m.Name).HasMaxLength(85);
    }
}

internal class fsd : IEntityTypeConfiguration<IdentityUserToken<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
    {
        builder.Property(m => m.LoginProvider).HasMaxLength(85);
        builder.Property(m => m.Name).HasMaxLength(85);
    }
}

internal class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.Property(userAccount => userAccount.Id).HasMaxLength(85);
        builder.Property(m => m.Name).HasMaxLength(85);
    }
}
