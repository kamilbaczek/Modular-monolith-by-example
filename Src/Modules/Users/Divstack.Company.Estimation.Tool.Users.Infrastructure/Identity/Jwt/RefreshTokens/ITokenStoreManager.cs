using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;

public interface ITokenStoreManager
{
    Task<bool> IsCurrentTokenActiveAsync();
    Task DeactivateCurrentAsync();
}
