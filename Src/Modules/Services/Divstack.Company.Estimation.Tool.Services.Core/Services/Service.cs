﻿namespace Divstack.Company.Estimation.Tool.Services.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using Attributes.Exceptions;
using Categories;
using UserAccess;
using Attribute = Attributes.Attribute;

public sealed class Service
{
    public Service()
    {
    }

    private Service(
        string name,
        string description,
        Category category,
        ICurrentUserService currentUserService)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Category = category;
        Attributes = new List<Attribute>();
        CreatedBy = currentUserService.GetPublicUserId();
    }

    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public List<Attribute> Attributes { get; init; }
    public Guid CreatedBy { get; init; }

    internal static Service Create(string name, string description, Category category,
        ICurrentUserService currentUserService)
    {
        return new Service(name, description, category, currentUserService);
    }

    internal void Update(string name, string description, Category category)
    {
        Name = name;
        Description = description;
        Category = category;
    }

    internal void AddAttribute(string name)
    {
        var attribute = Attribute.Create(this, name);
        Attributes.Add(attribute);
    }

    internal void DeleteAttribute(Guid id)
    {
        var attributeToRemove = Attributes.SingleOrDefault(value => value.Id == id);
        if (attributeToRemove is null)
        {
            throw new AttributeNotFoundException(id);
        }

        Attributes.Remove(attributeToRemove);
    }

    internal void AddAttributePotentialValue(Guid attributeId, string value)
    {
        var attribute = Attributes.SingleOrDefault(attribute => attribute.Id == attributeId);
        if (attribute is null)
        {
            throw new AttributeNotFoundException(attributeId);
        }

        attribute.AddPossibleValue(value);
    }

    internal void DeleteAttributePossibleValue(Guid attributeId, Guid possibleValueId)
    {
        var attribute = Attributes.SingleOrDefault(attribute => attribute.Id == attributeId);
        if (attribute is null)
        {
            throw new AttributeNotFoundException(attributeId);
        }

        attribute.DeletePossibleValue(possibleValueId);
    }
}
