﻿namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Core;

internal interface ITrelloTaskCreator
{
    Task CreateAsync(string listName, string taskName, string description,
        CancellationToken cancellationToken = default);
}
