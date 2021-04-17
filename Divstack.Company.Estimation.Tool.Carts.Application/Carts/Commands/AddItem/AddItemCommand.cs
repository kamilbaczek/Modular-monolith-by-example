using System;
using Divstack.Company.Estimation.Tool.Carts.Application.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.AddItem
{
    public sealed class AddItemCommand : ICommand
    {
        public AddItemCommand(Guid serviceId, long quantity)
        {
            Quantity = Quantity.From(quantity);
            ServiceId = serviceId;
        }

        public Quantity Quantity { get; }
        public Guid ServiceId { get; }
    }
}
