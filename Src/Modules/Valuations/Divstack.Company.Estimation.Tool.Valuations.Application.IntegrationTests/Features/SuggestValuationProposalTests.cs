using System;
using System.Globalization;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes.Services;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Features
{
    using static ValuationsTesting;

    public class SuggestValuationProposalTests : ValuationsTestBase
    {
        private const int OneMinuteInMs = 60000;


[Test]
         public async Task
             Given_SuggestProposal_When_CommandIsValid_Then_ValuationStateIsChangedToWaitForClientDecision()
         {
             await ValuationModuleHelper.RequestValuation();
             var valuationBeforeSuggestProposal = await ValuationModuleHelper.GetFirstRequestedValuation();
             var suggestProposalCommand =
                 FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuationBeforeSuggestProposal.Id);

             await ExecuteCommandAsync(suggestProposalCommand);

             var valuationAfterSuggestProposal = await ValuationModuleHelper.GetFirstRequestedValuation();
             valuationAfterSuggestProposal.Status.Should().Be("WaitForClientDecision");
         }
//
//         [Test]
//         public async Task
//             Given_SuggestProposal_When_CommandIsValid_Then_ProposalIsCorrectlySavedInDatabase()
//         {
//             await ValuationModuleHelper.RequestValuation();
//             var valuation = await ValuationModuleHelper.GetFirstRequestedValuation();
//             var suggestProposalCommand =
//                 FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuation.Id);
//
//             await ExecuteCommandAsync(suggestProposalCommand);
//
//             var proposal = await ValuationModuleHelper.GetRecentProposal(valuation.Id);
//             proposal.Should().BeEquivalentTo(suggestProposalCommand, opt => opt.ExcludingMissingMembers());
//             proposal.SuggestedBy.Should().Be(CurrentUserId);
//             DateTime.Parse(proposal.SuggestedFormatted).Should().BeCloseTo(DateTime.Now, OneMinuteInMs);
//         }
//
//         [Test]
//         [Ignore("Ignore for travic CI, test need open 25")]
//         public async Task Given_SuggestProposal_When_CommandIsValid_Then_CorrectEmailIsSend()
//         {
//             var server = FakeSmtp.Create(Configuration);
//             var request = await ValuationModuleHelper.RequestValuation();
//             var valuationBeforeSuggestProposal = await ValuationModuleHelper.GetFirstRequestedValuation();
//             var suggestProposalCommand =
//                 FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuationBeforeSuggestProposal.Id);
//
//             await ExecuteCommandAsync(suggestProposalCommand);
//
//             var message = await server.GetReceivedMessage(request.Email);
//             message.Should().NotBeNull();
//             message.AssertEqualsToAddress(request.Email);
//             message.AssertEqualsFromAddress(Configuration);
//             message.Data.Should().Contain(suggestProposalCommand.Value.ToString(CultureInfo.InvariantCulture));
//             server.Destroy();
//         }
//     }
// }
