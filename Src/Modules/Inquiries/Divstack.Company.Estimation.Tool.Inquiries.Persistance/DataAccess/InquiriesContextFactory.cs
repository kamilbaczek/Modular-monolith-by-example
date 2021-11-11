using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;

internal sealed class InquiriesContextFactory : DesignTimeDbContextFactoryBase<InquiriesContext>
{
    protected override InquiriesContext CreateNewInstance(DbContextOptions<InquiriesContext> options)
    {
        return new InquiriesContext(options);
    }
}
