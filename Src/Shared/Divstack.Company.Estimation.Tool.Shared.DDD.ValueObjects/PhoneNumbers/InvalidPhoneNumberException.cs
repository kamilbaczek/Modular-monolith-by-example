namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;

using System;

public sealed class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string value) : base(GetInvalidPhoneNumberMessage(value))
    {
    }
    private static string GetInvalidPhoneNumberMessage(string value) => $"Phone number `${value}`";
}
