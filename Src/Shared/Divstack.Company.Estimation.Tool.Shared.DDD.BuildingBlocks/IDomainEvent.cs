namespace Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

using System;
using MediatR;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}
