namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;

using Common.Contracts;
using Dtos;

public record struct GetValuationHistoryByIdQuery(Guid ValuationId) : IQuery<ValuationHistoryVm>;
