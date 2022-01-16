namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;

using System;

public sealed class InvalidPhoneNumberException : Exception
{
    private static string GetInvalidPhoneNumberMessage(string value) => $"Phone number `${value}`";
    public InvalidPhoneNumberException(string value) : base(GetInvalidPhoneNumberMessage(value))
    {
    }
}
