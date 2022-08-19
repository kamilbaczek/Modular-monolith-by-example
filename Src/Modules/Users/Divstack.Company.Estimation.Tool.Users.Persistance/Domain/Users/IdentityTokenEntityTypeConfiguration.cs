﻿namespace Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class IdentityTokenEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
    {
        builder.Property(m => m.LoginProvider).HasMaxLength(85);
        builder.Property(m => m.Name).HasMaxLength(85);
    }
}
