namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System.Threading.Tasks;
using Domain.Users;

internal interface IPasswordTokens
{
    Task<string> GeneratePasswordResetTokenAsync(UserAccount userAccount);
}
