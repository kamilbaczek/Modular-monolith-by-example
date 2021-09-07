using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Domain.Inquiries
{
    internal sealed class InquriesRepository : IInquiriesRepository
    {
        private readonly  InquiriesContext _inquiriesContext;

        public InquriesRepository(InquiriesContext inquiriesContext)
        {
            _inquiriesContext = inquiriesContext;
        }


        public async Task AddAsync(Inquiry inquiry, CancellationToken cancellationToken = default)
        {
            await _inquiriesContext.Inquiries.AddAsync(inquiry, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _inquiriesContext.SaveChangesAsync(cancellationToken);
        }
    }
}
