using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal
{
    public sealed class ApproveProposalCommandValidator : AbstractValidator<ApproveProposalCommand>
    {
        public ApproveProposalCommandValidator()
        {
            RuleFor(command => command.ProposalId).NotEmpty();
            RuleFor(command => command.ValuationId).NotEmpty();
        }
    }
}