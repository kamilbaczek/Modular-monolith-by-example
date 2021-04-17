using System;
using System.Text.Json.Serialization;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos
{
    public sealed class ServiceDto
    {
        [JsonConstructor]
        private ServiceDto()
        {
        }

        private ServiceDto(Guid id, string name, string description, CategoryDto category, Guid createdBy)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            CreatedBy = createdBy;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CreatedBy { get; private set; }

        public CategoryDto Category { get; private set; }

        internal static ServiceDto Map(Service service)
        {
            var category = CategoryDto.Map(service.Category);
            return new ServiceDto(service.Id, service.Name, service.Description, category, service.CreatedBy);
        }
    }
}
