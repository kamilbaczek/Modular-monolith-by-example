namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using States;

public sealed class CannotCompleteValuationWithNoProposalException : InvalidOperationException
{
    public CannotCompleteValuationWithNoProposalException(ValuationId valuationId) :
        base($"Cannot complete Valuation {valuationId} with no proposals")
    {
    }
}
