namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services.Fakers;

using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

internal static class ServicesFaker
{
    internal static CreateServiceRequest CreateService(Guid categoryId)
    {
        return new CreateServiceRequest
        {
            CategoryId = categoryId,
            Description = Faker.Lorem.Paragraph(),
            Name = Faker.Lorem.GetFirstWord()
        };
    }

    internal static CreateCategoryRequest CreateCategory()
    {
        return new CreateCategoryRequest
        {
            Description = Faker.Lorem.Paragraph(),
            Name = Faker.Lorem.GetFirstWord(),
        };
    }
}
