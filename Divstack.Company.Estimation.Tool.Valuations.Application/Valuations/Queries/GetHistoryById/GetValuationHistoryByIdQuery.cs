using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById
{
    public record GetValuationHistoryByIdQuery(Guid ValuationId) : IQuery<ValuationHistoryVm>;
}
