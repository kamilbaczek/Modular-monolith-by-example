using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Persistance.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

[assembly:InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests")]
namespace Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess
{
    internal class UsersContext : IdentityDbContext<UserAccount, ApplicationRole, string>
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAccountEntityTypeConfiguration).Assembly);
        }
    }
}
