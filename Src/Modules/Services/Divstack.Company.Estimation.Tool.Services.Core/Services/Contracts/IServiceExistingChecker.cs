using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts
{
    public interface IServiceExistingChecker
    {
        Task<bool> ExistAsync(Guid serviceId);
        Task<bool> ExistAsync(IReadOnlyCollection<Guid> serviceIds);
    }
}
