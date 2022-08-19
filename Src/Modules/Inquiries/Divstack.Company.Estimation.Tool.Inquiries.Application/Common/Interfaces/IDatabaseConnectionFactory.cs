[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Persistance")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Interfaces;

internal interface IDatabaseConnectionFactory : IDisposable
{
    IDbConnection Create();
}
