namespace Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Archive;

using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Priorities.Domain;

internal sealed class ArchivePriorityCommandCommandHandler : IHandleMessages<ProposalSuggested>
{
    private readonly IPrioritiesRepository _prioritiesRepository;
    public ArchivePriorityCommandCommandHandler(IPrioritiesRepository prioritiesRepository) => 
        _prioritiesRepository = prioritiesRepository;

    public async Task Handle(ProposalSuggested proposalSuggested, IMessageHandlerContext context)
    {
        var valuationId = ValuationId.Create(proposalSuggested.ValuationId);
        var priority = await _prioritiesRepository.GetAsync(valuationId, context.CancellationToken);
        if (priority is null)
            throw new NotFoundException(proposalSuggested.ValuationId.ToString(), nameof(Priority));

        priority.Archive();

        await _prioritiesRepository.CommitAsync(priority, context.CancellationToken);
    }
}
