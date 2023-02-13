namespace Divstack.Company.Estimation.Tool.Valuations.Application.AcceptanceTests.Features.Common.Fakes;

using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;

internal static class ValuationApproveFaker
{
    internal static ApproveProposalCommand Create(Guid valuationId, Guid proposalId) =>
        new(proposalId, valuationId);
}
