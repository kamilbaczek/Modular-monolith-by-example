namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Core;

using System.Threading;
using System.Threading.Tasks;

internal interface ITrelloTaskCreator
{
    Task CreateAsync(string listName, string taskName, string description,
        CancellationToken cancellationToken = default);
}
