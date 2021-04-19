using System;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.UserAccess
{
    public interface ICurrentUserService
    {
        Guid GetPublicUserId();
    }
}