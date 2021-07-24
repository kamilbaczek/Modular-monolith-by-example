using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Events;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Exceptions;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts
{
    public sealed class Cart : Entity, IAggregateRoot
    {
        private Cart()
        {
            // Only for EF
        }

        private Cart(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Status = Status.Active;
            Items = new List<CartItem>();
            CreationDate = DateTime.Now;
            LastActivity = DateTime.Now;
        }

        public Guid UserId { get; }
        public bool IsActive => Status == Status.Active;

        private Guid Id { get; }
        private Status Status { get; set; }
        private DateTime CreationDate { get; }
        private DateTime LastActivity { get; set; }
        private IList<CartItem> Items { get; }

        public void Abandon()
        {
            Status = Status.Abandoned;
            AddDomainEvent(new CartAbandonedEvent());
        }

        public void Submit()
        {
            Status = Status.Submitted;
            AddDomainEvent(new CartSubmittedEvent());
        }

        public static Cart Create(Guid userId)
        {
            return new(userId);
        }

        public async Task AddItemAsync(Guid productId,
            Quantity quantity,
            IServiceExistingChecker serviceExistingChecker)
        {
            if (!IsActive)
                throw new CannotAddItemToNotActiveCartException();
            var productExist = await serviceExistingChecker.ExistAsync(productId);
            if (!productExist)
                throw new UnableAddToCartNonExistentProductException();
            var itemWithSameProduct = FindItemByProductOrDefault(productId);
            if (itemWithSameProduct is not null)
            {
                itemWithSameProduct.AddQuantity(quantity);
                return;
            }

            var newItem = CartItem.Create(productId, quantity);
            Items.Add(newItem);
            LastActivity = DateTime.Now;
        }


        public void ChangeQuantity(Guid productId, Quantity quantity)
        {
            if (!IsActive)
                throw new CannotAddItemToNotActiveCartException();
            var item = FindItemByProduct(productId);
            item.ChangeQuantity(quantity);
            LastActivity = DateTime.Now;
        }

        public void RemoveItem(Guid productId)
        {
            var itemToRemove = FindItemByProduct(productId);
            Items.Remove(itemToRemove);
            LastActivity = DateTime.Now;
        }

        public void Clear()
        {
            Items.Clear();
            LastActivity = DateTime.Now;
        }

        private CartItem FindItemByProductOrDefault(Guid productId)
        {
            return Items.SingleOrDefault(item => item.ProductId == productId);
        }

        private CartItem FindItemByProduct(Guid productId)
        {
            return Items.Single(item => item.ProductId == productId);
        }
    }
}
