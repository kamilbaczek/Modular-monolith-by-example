#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

using System;
using System.Net.Mail;
using BuildingBlocks;

public sealed class Email : ValueObject
{
    private Email()
    {
    }

    private Email(string emailAddress)
    {
        var isValid = IsValid(emailAddress);
        if (!isValid)
        {
            throw new InvalidEmailFormatException(emailAddress);
        }

        Value = emailAddress;
    }

    public string Value { get; }

    public static Email Of(string emailAddress)
    {
        return new Email(emailAddress);
    }

    private static bool IsValid(string emailAddress)
    {
        try
        {
            var mailAddress = new MailAddress(emailAddress);

            return !string.IsNullOrEmpty(mailAddress.Address);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
