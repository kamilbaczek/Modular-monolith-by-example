namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using System;

public sealed class ValuationCompletedException : InvalidOperationException
{
    public ValuationCompletedException(ValuationId valuationId) :
        base($"Cannot execute operation on completed valuation :{valuationId}")
    {
    }
}
