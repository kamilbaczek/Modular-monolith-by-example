﻿namespace Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

using System;

public sealed class InvalidEmailFormatException : InvalidOperationException
{
    public InvalidEmailFormatException(string emailAddress) : base($"'{emailAddress}' has invalid format")
    {
    }
}
