using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries
{
    public interface IInquiriesRepository
    {
        Task AddAsync(Inquiry inquiry, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
