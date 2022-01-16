namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.PhoneNumbers;

using System.Text.RegularExpressions;
using BuildingBlocks;
using Inquiries.Domain.Inquiries.Clients;

public sealed class PhoneNumber : ValueObject
{
    private const string Pattern = @"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$";
    private PhoneNumber(string value)
    {
        var phoneIsValid = new Regex(Pattern).IsMatch(value);
        if (!phoneIsValid)
            throw new InvalidPhoneNumberException(value);
        Value = value;
    }

    private string Value { get; }

    public static PhoneNumber Of(string value)
    {
        return new PhoneNumber(value);
    }
}
