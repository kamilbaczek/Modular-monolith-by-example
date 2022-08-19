namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById;

using Common.Contracts;
using Dtos;

public record struct GetValuationProposalsByIdQuery(Guid ValuationId) : IQuery<ValuationProposalsVm>;
