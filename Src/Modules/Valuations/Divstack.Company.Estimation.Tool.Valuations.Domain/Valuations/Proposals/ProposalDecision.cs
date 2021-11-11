using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

public record ProposalDecision
{
    private const string Accept = "Accept";

    private const string Reject = "Reject";

    private const string EmptyDecision = "NoDecision";

    private ProposalDecision(DateTime? date, string code)
    {
        Date = date;
        Code = code;
    }

    private DateTime? Date { get; }

    private string Code { get; }


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
