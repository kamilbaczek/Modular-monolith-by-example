using System;
using System.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Persistance")]
namespace Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces
{
    internal interface IDatabaseConnectionFactory : IDisposable
    {
        IDbConnection Create();
    }
}
