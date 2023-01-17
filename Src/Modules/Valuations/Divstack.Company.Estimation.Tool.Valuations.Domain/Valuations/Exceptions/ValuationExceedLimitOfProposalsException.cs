namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public sealed class ValuationExceedLimitOfProposalsException : InvalidOperationException
{
    public ValuationExceedLimitOfProposalsException(ValuationId valuationId, int limit) : base($"Valuation with id: {valuationId} exceed limit of proposals: {limit}")
    {
    }
}
