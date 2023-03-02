namespace Divstack.Company.Estimation.Tool.Services.Api.UserAccess;

using System.Linq;
using System.Security.Claims;
using Core.UserAccess;
using Microsoft.AspNetCore.Http;

internal sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetPublicUserId()
    {
        var userPublicId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId) ? Guid.Parse(userPublicId) : Guid.Empty;
    }

    public string[] GetCurrentUserRoles()
    {
        var roles = _httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(r => r.Value).ToArray()!;
        
        return roles;
    }
}
