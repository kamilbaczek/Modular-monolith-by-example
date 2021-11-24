namespace Divstack.Company.Estimation.Tool.Inquiries.Api.Common.UserAccess;

using System.Security.Claims;
using Domain.Common.UserAccess;
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
        var userPublicId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId?.Value) ? Guid.Parse(userPublicId.Value) : Guid.Empty;
    }
}
