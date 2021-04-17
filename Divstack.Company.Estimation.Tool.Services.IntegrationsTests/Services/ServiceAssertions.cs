using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using FluentAssertions;

namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services
{
    internal static class ServiceAssertions
    {
        internal static void AssertEquals(this ServiceDto left, Service right, Category category)
        {
            left.Id.Should().Be(right.Id);
            left.Name.Should().Be(right.Name);
            left.Description.Should().Be(right.Description);
            left.Category.AssertEquals(category);
        }

        private static void AssertEquals(this CategoryDto left, Category right)
        {
            left.Id.Should().Be(right.Id);
            left.Name.Should().Be(right.Name);
        }
    }
}
