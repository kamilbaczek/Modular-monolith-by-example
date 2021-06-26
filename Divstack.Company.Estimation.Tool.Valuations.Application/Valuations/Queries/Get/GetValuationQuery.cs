using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get
{
    public record GetValuationQuery(Guid ValuationId) : IQuery<ValuationVm>;
}