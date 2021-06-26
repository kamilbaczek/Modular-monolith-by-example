using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Core
{
    internal interface ITrelloTaskCreator
    {
        Task CreateAsync(string listName, string taskName, string description,
            CancellationToken cancellationToken = default);
    }
}