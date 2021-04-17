using System;
using System.Linq;
using System.Security.Claims;
using Divstack.Company.Estimation.Tool.Services.Core.UserAccess;
using Microsoft.AspNetCore.Http;

namespace Divstack.Company.Estimation.Tool.Services.Api.UserAccess
{
    internal sealed class CurrentUserService : ICurrentUserService
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
}
