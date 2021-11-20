namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get;

using System;
using Common.Contracts;
using Dtos;

public record GetValuationQuery(Guid ValuationId) : IQuery<ValuationVm>;
