using System;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
    string[] GetCurrentUserRoles();
}
