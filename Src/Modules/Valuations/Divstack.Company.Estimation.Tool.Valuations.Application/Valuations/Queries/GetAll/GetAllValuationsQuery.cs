namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

using Common.Contracts;

public record struct GetAllValuationsQuery : IQuery<ValuationListVm>
{
    public static GetAllValuationsQuery Create() => new();
}
