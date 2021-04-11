using System;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.UserAccess
{
    public interface ICurrentUserService
    {
        Guid GetPublicUserId();
    }
}
