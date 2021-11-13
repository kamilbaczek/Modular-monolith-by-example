namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tool.Users.Domain.Users;

internal class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.Property(userAccount => userAccount.Id).HasMaxLength(85);
        builder.Property(m => m.Name).HasMaxLength(85);
    }
}
