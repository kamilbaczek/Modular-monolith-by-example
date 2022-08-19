﻿namespace Divstack.Company.Estimation.Tool.Users.Api;

using System;
using System.Linq;
using System.Security.Claims;
using Application.Authentication;
using Microsoft.AspNetCore.Http;

internal class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid GetPublicUserId()
    {
        var userPublicId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId) ? Guid.Parse(userPublicId) : Guid.Empty;
    }

    public string[] GetCurrentUserRoles()
    {
        var tmp = httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(r => r.Value).ToArray();
        return tmp;
    }
}
