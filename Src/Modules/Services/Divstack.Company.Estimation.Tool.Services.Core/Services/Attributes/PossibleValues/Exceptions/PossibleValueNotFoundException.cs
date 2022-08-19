﻿namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Exceptions;

using System;

internal sealed class PossibleValueNotFoundException : InvalidOperationException
{
    public PossibleValueNotFoundException(Guid id) : base($"Attribute possible value: {id} not found")
    {
    }
}
