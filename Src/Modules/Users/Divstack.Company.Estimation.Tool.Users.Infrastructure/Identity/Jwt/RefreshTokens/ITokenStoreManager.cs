namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

using System.Threading.Tasks;

public interface ITokenStoreManager
{
    Task<bool> IsCurrentTokenActiveAsync();
    Task DeactivateCurrentAsync();
}
