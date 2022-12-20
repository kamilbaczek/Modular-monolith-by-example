namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Common.Fakes;

using Valuations.Commands.ApproveProposal;

internal static class ValuationApproveFaker
{
    internal static ApproveProposalCommand Create(Guid valuationId, Guid proposalId) =>
        new(proposalId, valuationId);
}
