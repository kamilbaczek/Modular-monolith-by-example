using System;
using Divstack.Company.Estimation.Tool.Products.Core.UserAccess;

namespace Divstack.Company.Estimation.Tool.Products.IntegrationsTests.Fakes
{
    public class FakeCurrentUserService : ICurrentUserService
    {
        public Guid GetPublicUserId()
        {
            return Guid.NewGuid();
        }

        public string[] GetCurrentUserRoles()
        {
            throw new NotImplementedException();
        }
    }
}
