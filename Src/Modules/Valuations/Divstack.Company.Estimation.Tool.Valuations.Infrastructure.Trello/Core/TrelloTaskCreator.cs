using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Configuration;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Core.Exceptions;
using Manatee.Trello;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Core
{
    internal sealed class TrelloTaskCreator : ITrelloTaskCreator
    {
        private readonly ITrelloConfiguration _configuration;

        public TrelloTaskCreator(ITrelloConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CreateAsync(
            string listName,
            string taskName,
            string description,
            CancellationToken cancellationToken = default)
        {
            var factory = new TrelloFactory();
            var board = factory.Board(_configuration.BoardId);
            await board.Refresh(ct: cancellationToken);
            var list = board.Lists.FirstOrDefault(listInBoard => listInBoard.Name == listName);
            if (list is null)
                throw new TrelloTodoListNotFound(listName);

            await list.Cards.Add(taskName, description: description, ct: cancellationToken);
        }
    }
}