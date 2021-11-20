namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using System;

public sealed class ValuationCompletedException : InvalidOperationException
{
    private static string GetMessage(ValuationId valuationId) => $"Cannot execute operation on completed valuation :{valuationId}";
    public ValuationCompletedException(ValuationId valuationId) :
        base(GetMessage(valuationId))
    {
    }
}
