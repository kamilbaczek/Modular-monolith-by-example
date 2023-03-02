namespace Divstack.Company.Estimation.Tool.Valuations.Api.UserAccess;

using System.Security.Claims;
using Domain.UserAccess;
using Microsoft.AspNetCore.Http;

[ExcludeFromCodeCoverage]
internal sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetPublicUserId()
    {
        var userPublicId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId?.Value) ? Guid.Parse(userPublicId.Value) : Guid.Empty;
    }
}
