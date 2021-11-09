using System;
using System.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Persistance")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces
{
    internal interface IDatabaseConnectionFactory : IDisposable
    {
        IDbConnection Create();
    }
}