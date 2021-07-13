using System;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity
{
    public class QuantityCannotBeNegative : Exception
    {
        public QuantityCannotBeNegative() : base("Quantity cannot be negative")
        {
        }
    }
}