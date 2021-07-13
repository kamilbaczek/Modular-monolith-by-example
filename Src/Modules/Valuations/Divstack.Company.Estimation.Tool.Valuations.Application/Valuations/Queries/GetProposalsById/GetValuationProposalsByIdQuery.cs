using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById
{
    public record GetValuationProposalsByIdQuery(Guid ValuationId) : IQuery<ValuationProposalsVm>;
}