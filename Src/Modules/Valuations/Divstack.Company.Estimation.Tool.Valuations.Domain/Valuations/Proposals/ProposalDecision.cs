#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

public sealed class ProposalDecision : ValueObject
{
    private const string Accept = "Accept";

    private const string Reject = "Reject";

    private const string EmptyDecision = "NoDecision";

    private ProposalDecision()
    {
    }

    private ProposalDecision(DateTime? date, string code)
    {
        Date = date;
        Code = code;
    }

    private DateTime? Date { get; init; }

    private string Code { get; init; }


    internal static ProposalDecision AcceptDecision(DateTime date)
    {
        return new ProposalDecision(date, Accept);
    }

    internal static ProposalDecision NoDecision()
    {
        return new ProposalDecision(null, EmptyDecision);
    }

    internal static ProposalDecision RejectDecision(DateTime date)
    {
        return new ProposalDecision(date, Reject);
    }
}
