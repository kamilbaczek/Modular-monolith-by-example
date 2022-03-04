namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.PhoneNumbers;

using System;

public sealed class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string value) : base(GetInvalidPhoneNumberMessage(value))
    {
    }
    private static string GetInvalidPhoneNumberMessage(string value) => $"Phone number `${value}`";
}
