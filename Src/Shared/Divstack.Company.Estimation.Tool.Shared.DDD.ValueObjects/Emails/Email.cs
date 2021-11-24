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

    private bool IsValid(string emailAddress)
    {
        try
        {
            var mailAddress = new MailAddress(emailAddress);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
