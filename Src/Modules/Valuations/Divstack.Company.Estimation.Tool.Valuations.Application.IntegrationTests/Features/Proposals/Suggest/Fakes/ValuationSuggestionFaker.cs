namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Proposals.Suggest.Fakes;

using Faker;
using Valuations.Commands.SuggestProposal;

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
