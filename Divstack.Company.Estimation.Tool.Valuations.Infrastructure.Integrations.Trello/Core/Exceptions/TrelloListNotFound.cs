using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Core.Exceptions
{
    public sealed class TrelloTodoListNotFound : InvalidOperationException
    {
        internal TrelloTodoListNotFound(string listName) : base(GetNotFoundMessage(listName))
        {
        }

        private static string GetNotFoundMessage(string listName) =>
            $"Trello list '{listName}' not found.";
    }
}