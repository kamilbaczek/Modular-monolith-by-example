using System;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions
{
    public sealed class ValuationCompletedException : InvalidOperationException
    {
        public ValuationCompletedException(ValuationId valuationId) :
            base($"Cannot execute operation on completed valuation :{valuationId} ")
        {}
    }
}