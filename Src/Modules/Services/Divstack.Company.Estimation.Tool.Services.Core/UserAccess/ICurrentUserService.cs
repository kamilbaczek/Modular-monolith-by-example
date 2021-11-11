using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.UserAccess;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
    string[] GetCurrentUserRoles();
}
