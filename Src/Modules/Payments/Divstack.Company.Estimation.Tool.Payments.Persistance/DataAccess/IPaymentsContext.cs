namespace Divstack.Company.Estimation.Tool.Payments.Persistance.DataAccess;

using MongoDB.Driver;
using Payments.Domain.Payments;

internal interface IPaymentsContext
{
    public IMongoCollection<Payment> Payments { get; }
}
