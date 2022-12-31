namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Extensions.Proposals;

internal static class ProposalsExtensions
{
    internal static IReadOnlyCollection<Proposal> GetNotCancelled(this IEnumerable<Proposal> proposals) =>
        proposals
            .Where(proposal => !proposal.IsCancelled)
            .ToList();

    internal static Proposal? Get(this IReadOnlyCollection<Proposal> proposals, ProposalId proposalId) =>
        proposals
            .FirstOrDefault(proposal => proposal.Id == proposalId);

    internal static Proposal? GetWithNoDecision(this IReadOnlyCollection<Proposal> proposals) => proposals
        .SingleOrDefault(proposal => proposal.HasDecision == false);
}
