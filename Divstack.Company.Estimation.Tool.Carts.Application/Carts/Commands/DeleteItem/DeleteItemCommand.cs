using System;
using Divstack.Company.Estimation.Tool.Carts.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.DeleteItem
{
    public sealed class DeleteItemCommand : ICommand
    {
        public DeleteItemCommand(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; }
    }
}
