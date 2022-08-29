namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get;

using Common.Contracts;
using Dtos;

public record struct GetValuationQuery(Guid ValuationId) : IQuery<ValuationVm>
{
    public static GetValuationQuery Create(Guid valuationId) => new(valuationId);
}
