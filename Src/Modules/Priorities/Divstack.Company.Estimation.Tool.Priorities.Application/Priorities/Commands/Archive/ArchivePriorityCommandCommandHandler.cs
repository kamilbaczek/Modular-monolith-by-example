namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Commands.Archive;

using Ardalis.GuardClauses;
using Common.Interfaces;
using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using MediatR;
using Redefine;

internal sealed class ArchivePriorityCommandCommandHandler : IRequestHandler<ArchivePriorityCommand>
{
    public ArchivePriorityCommandCommandHandler()
    {
    }
    public async Task<Unit> Handle(ArchivePriorityCommand command, CancellationToken cancellationToken)
    {
        return Unit.Value;
    }
}
