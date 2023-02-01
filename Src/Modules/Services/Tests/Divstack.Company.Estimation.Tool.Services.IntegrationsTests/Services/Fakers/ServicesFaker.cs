namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services.Fakers;

using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

internal static class ServicesFaker
{
    internal static CreateServiceRequest CreateService(Guid categoryId) => new(categoryId,Faker.Lorem.GetFirstWord(), Faker.Lorem.Paragraph());

    internal static CreateCategoryRequest CreateCategory() => new(Faker.Lorem.GetFirstWord(), Faker.Lorem.Paragraph());
}
