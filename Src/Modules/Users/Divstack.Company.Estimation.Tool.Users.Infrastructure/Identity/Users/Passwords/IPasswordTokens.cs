namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Passwords;

using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;

internal interface IPasswordTokens
{
    Task<string> GeneratePasswordResetTokenAsync(UserAccount userAccount);
}
