using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Domain.Inquiries
{
    internal sealed class InquiriesRepository : IInquiriesRepository
    {
        private readonly InquiriesContext _inquiriesContext;

        public InquiriesRepository(InquiriesContext inquiriesContext)
        {
            _inquiriesContext = inquiriesContext;
        }


        public async Task PersistAsync(Inquiry inquiry, CancellationToken cancellationToken = default)
        {
            await _inquiriesContext.Inquiries.AddAsync(inquiry, cancellationToken);
            await CommitAsync(cancellationToken);
        }

        private async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _inquiriesContext.SaveChangesAsync(cancellationToken);
        }
    }
}