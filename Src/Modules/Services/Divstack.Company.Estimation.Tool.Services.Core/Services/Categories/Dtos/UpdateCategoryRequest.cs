namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;

using System;

public sealed record UpdateCategoryRequest(string Name, string Description, Guid CategoryId, Guid ServiceId);
