namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get;

using System;
using Contracts;
using Dtos;

public record GetValuationQuery(Guid ValuationId) : IQuery<ValuationVm>;
