namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tool.Users.Domain.Users;

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
