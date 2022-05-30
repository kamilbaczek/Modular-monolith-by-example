namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById;

using Dtos;
using Inquiries.Application.Common.Contracts;

public record GetValuationProposalsByIdQuery(Guid ValuationId) : IQuery<ValuationProposalsVm>;
