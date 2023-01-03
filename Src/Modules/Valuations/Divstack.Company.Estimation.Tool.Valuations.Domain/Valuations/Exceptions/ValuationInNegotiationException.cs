namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public class ValuationInNegotiationException : InvalidOperationException
{
    private static string GetMessage(ValuationId valuationId) => $"Cannot suggest proposal for valuation {valuationId} because there is already a proposal waiting for decision";

    public ValuationInNegotiationException(ValuationId valuationId) : base(GetMessage(valuationId))
    {
    }
}
