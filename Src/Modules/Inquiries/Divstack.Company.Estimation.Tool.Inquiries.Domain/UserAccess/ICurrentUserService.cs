using System;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.UserAccess
{
    public interface ICurrentUserService
    {
        Guid GetPublicUserId();
    }
}
