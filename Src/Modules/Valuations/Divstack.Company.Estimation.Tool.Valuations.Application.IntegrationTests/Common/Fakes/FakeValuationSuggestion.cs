using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;
using Faker;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes
{
    internal static class FakeValuationSuggestion
    {
        internal static SuggestProposalCommand GenerateFakeSuggestProposalCommand(Guid valuationId)
        {
            return new()
            {
                Currency = Currency.ThreeLetterCode(),
                Description = Lorem.Sentence(),
                ValuationId = valuationId,
                Value = 333m
            };
        }
    }
}