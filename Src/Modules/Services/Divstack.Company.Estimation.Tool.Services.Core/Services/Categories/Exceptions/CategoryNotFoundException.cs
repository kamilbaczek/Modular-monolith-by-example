using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Exceptions;

internal sealed class CategoryNotFoundException : InvalidOperationException
{
    public CategoryNotFoundException(Guid id) : base($"Category: {id} not found")
    {
    }
}
