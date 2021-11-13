namespace Divstack.Company.Estimation.Tool.Services.Core.UserAccess;

using System;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
    string[] GetCurrentUserRoles();
}
