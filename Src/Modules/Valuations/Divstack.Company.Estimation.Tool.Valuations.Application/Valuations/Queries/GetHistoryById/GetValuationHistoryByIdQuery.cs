namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;

using System;
using Contracts;
using Dtos;

public record GetValuationHistoryByIdQuery(Guid ValuationId) : IQuery<ValuationHistoryVm>;
