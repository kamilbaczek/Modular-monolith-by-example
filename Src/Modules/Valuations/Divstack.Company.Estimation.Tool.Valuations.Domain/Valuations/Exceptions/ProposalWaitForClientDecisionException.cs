namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public class ProposalWaitForClientDecisionException : InvalidOperationException
{
    private static string GetMessage(ValuationId valuationId) => $"Cannot suggest proposal for valuation {valuationId} because there is already a proposal waiting for decision";

    public ProposalWaitForClientDecisionException(ValuationId valuationId) : base(GetMessage(valuationId))
    {
    }
}
