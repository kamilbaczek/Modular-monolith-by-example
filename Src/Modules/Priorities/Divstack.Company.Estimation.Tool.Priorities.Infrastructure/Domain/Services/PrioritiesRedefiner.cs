namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.Services;

using Application.Common.Contracts;
using Application.Priorities.Commands.Redefine;
using Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Tool.Priorities.Domain;

internal sealed class PrioritiesRedefiner : IPrioritiesRedefiner
{
    private readonly IPrioritiesModule _prioritiesModule;
    
    public PrioritiesRedefiner(IPrioritiesModule prioritiesModule) => 
        _prioritiesModule = prioritiesModule;

    public async Task RedefineAllAsync()
    {
        var query = GetPrioritiesQuery.Create();
        var prioritiesList = await _prioritiesModule.ExecuteQueryAsync(query);
        foreach (var priority in prioritiesList.Priorities)
            await RedefinePriorityAsync(priority.PriorityId, priority.ValuationId, priority.InquiryId);
    }

    private async Task RedefinePriorityAsync(Guid priorityId, Guid valuationId, Guid inquiryId)
    {
        var command = new RedefinePriorityCommand
        {
            PriorityId = priorityId,
            ValuationId = valuationId,
            InquiryId = inquiryId
        };
        await _prioritiesModule.ExecuteCommandAsync(command);
    }
}
