using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Orders.Orders
{
    internal class Order
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateTime CreatedDate { get; }
        private Status Status { get; }
        private IList<OrderItem> OrderItems { get; }
    }
}