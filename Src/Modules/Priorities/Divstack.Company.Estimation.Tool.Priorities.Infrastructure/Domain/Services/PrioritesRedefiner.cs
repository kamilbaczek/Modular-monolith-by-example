namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.Services;

using Common.Contracts;
using Priorities.Commands.Redefine;
using Priorities.Queries.GetPrioritiesByValuationsIds;
using Tool.Priorities.Domain;

internal sealed class PrioritesRedefiner : IPrioritiesRedefiner
{
    private readonly IPrioritiesModule _prioritiesModule;
    public PrioritesRedefiner(IPrioritiesModule prioritiesModule)
    {
        _prioritiesModule = prioritiesModule;
    }

    public async Task RedefineAll()
    {
      var query = new GetPrioritiesQuery();
      var prioritiesList = await _prioritiesModule.ExecuteQueryAsync(query);
      foreach (var priority in prioritiesList.Priorities)
      {
          await RedefinePriority(priority.PriorityId, priority.ValuationId, priority.InquiryId);
      }
    }

    private async Task RedefinePriority(Guid priorityId, Guid valuationId, Guid inquiryId)
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
