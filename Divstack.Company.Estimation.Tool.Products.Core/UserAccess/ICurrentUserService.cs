using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.UserAccess
{
    public interface ICurrentUserService
    {
        Guid GetPublicUserId();
        string[] GetCurrentUserRoles();
    }
}
