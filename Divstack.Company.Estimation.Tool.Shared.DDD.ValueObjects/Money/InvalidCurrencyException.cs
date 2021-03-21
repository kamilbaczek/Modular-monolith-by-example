using System;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Money
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string currency) : base($"{currency} is invalid")
        {

        }
    }
}