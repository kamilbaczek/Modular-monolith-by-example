﻿namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dtos;
using Exceptions;

internal sealed class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoriesService(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoriesRepository.GetAllAsync(cancellationToken);
        var categoriesDtos = categories.Select(CategoryDto.Map).ToList();

        return categoriesDtos;
    }

    public async Task<Guid> CreateAsync(CreateCategoryRequest createCategoryRequest,
        CancellationToken cancellationToken = default)
    {
        var category = Category.Create(createCategoryRequest.Name, createCategoryRequest.Description);
        await _categoriesRepository.AddAsync(category, cancellationToken);

        return category.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _categoriesRepository.GetAsync(id, cancellationToken);
        if (category is null)
        {
            throw new CategoryNotFoundException(id);
        }

        await _categoriesRepository.DeleteAsync(category, cancellationToken);
    }
}
