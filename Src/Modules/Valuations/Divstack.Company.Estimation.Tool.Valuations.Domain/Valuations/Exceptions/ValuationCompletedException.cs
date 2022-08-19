namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public sealed class ValuationCompletedException : InvalidOperationException
{
    public ValuationCompletedException(ValuationId valuationId) :
        base(GetMessage(valuationId))
    {
    }
    private static string GetMessage(ValuationId valuationId)
    {
        return $"Cannot execute operation on completed valuation :{valuationId}";
    }
}
