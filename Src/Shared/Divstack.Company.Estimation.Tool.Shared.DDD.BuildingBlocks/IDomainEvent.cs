using System;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}
