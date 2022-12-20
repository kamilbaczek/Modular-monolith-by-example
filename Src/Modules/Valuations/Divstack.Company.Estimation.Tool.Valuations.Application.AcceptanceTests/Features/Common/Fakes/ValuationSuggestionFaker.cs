namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Common.Fakes;

using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;
using Faker;

internal static class ValuationSuggestionFaker
{
    internal static SuggestProposalCommand Create(Guid valuationId, decimal value, string currency)
    {
        return new SuggestProposalCommand
        {
            Currency = currency,
            Description = Lorem.Sentence(),
            ValuationId = valuationId,
            Value = value
        };
    }
}
