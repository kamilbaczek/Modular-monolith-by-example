namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public sealed class CannotChangePriorityException : InvalidOperationException
{
    public CannotChangePriorityException(ValuationId valuationId) :
        base(GetMessage(valuationId))
    {
    }
    private static string GetMessage(ValuationId valuationId)
    {
        return $"Cannot execute operation on valuation :{valuationId} priority. Proposal has to be in wait for proposal state";
    }
}
