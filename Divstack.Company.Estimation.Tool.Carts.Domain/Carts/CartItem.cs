using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts
{
    public sealed class CartItem
    {
        private CartItem(Guid productId, Quantity quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
        }

        private CartItem()
        {
        }

        public void ChangeQuantity(Quantity quantity)
        {
            Quantity  = quantity;
        }

        public void AddQuantity(Quantity quantity)
        {
            Quantity += quantity;
        }

        public static CartItem Create(Guid productId, Quantity quantity)
        {
            return new(productId, quantity);
        }

        private Guid Id { get; }
        internal Guid ProductId { get; }
        private Quantity Quantity { get; set; }
    }
}
