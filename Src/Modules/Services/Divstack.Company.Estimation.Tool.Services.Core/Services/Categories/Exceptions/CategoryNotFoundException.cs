namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Exceptions;

using System;

internal sealed class CategoryNotFoundException : InvalidOperationException
{
    public CategoryNotFoundException(Guid id) : base($"Category: {id} not found")
    {
    }
}
