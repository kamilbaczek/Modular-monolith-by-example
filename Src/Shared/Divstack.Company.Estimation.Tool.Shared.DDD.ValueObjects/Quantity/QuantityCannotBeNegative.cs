namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Quantity;

using System;

public class QuantityCannotBeNegative : Exception
{
    public QuantityCannotBeNegative() : base("Quantity cannot be negative")
    {
    }
}
