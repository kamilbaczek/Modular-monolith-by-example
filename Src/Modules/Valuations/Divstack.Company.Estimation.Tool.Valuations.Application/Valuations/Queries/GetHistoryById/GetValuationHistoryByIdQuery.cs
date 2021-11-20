namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;

using System;
using Common.Contracts;
using Dtos;

public record GetValuationHistoryByIdQuery(Guid ValuationId) : IQuery<ValuationHistoryVm>;
