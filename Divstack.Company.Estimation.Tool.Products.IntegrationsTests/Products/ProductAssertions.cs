using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using FluentAssertions;

namespace Divstack.Company.Estimation.Tool.Products.IntegrationsTests.Products
{
    internal static class ProductAssertions
    {
        internal static void AssertEquals(this ProductDto left, Product right, Category category)
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
