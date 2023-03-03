namespace Divstack.Company.Estimation.Tool.Users.Api;

using System;
using System.Linq;
using System.Security.Claims;
using Application.Authentication;
using Microsoft.AspNetCore.Http;

[ExcludeFromCodeCoverage]
internal class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor) => this._httpContextAccessor = httpContextAccessor;

    public Guid GetPublicUserId()
    {
        var userPublicId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId) ? Guid.Parse(userPublicId) : Guid.Empty;
    }

    public string[] GetCurrentUserRoles()
    {
        var userRoles = _httpContextAccessor.HttpContext?.User
            .FindAll(ClaimTypes.Role)
            .Select(r => r.Value)
            .ToArray();
        
        return userRoles;
    }
}
