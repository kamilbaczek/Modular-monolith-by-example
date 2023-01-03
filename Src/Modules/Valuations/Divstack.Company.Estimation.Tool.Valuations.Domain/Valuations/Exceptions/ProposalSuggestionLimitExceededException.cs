namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public class ProposalSuggestionLimitExceededException : InvalidOperationException
{
    private static string GetMessage(int proposalLimit) => $"Cannot suggest more than {proposalLimit} proposals";

    public ProposalSuggestionLimitExceededException(int proposalLimit) : base(GetMessage(proposalLimit))
    {
    }
}
