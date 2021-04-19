using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess
{
    public interface ICurrentUserService
    {
        Guid GetPublicUserId();
    }
}