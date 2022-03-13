namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;

using Common.Contracts;
using Dtos;
using Microsoft.AspNetCore.Mvc;

public record GetValuationHistoryByIdQuery(Guid ValuationId) : IQuery<ValuationHistoryVm>;
