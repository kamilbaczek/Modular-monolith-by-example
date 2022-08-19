namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
    string[] GetCurrentUserRoles();
}
