using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Api;
using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using Divstack.Company.Estimation.Tool.Products.IntegrationsTests.Fakes;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Json;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Products.IntegrationsTests.Products
{
    public class ProductsTests : ProductsModuleIntegrationTest
    {
        [Fact]
        public async Task Given_GetAll_WithoutAnyProductsReturnsEmptyResponse()
        {
            var client = await Application.GetAuthenticatedClientAsync();

            var response = await client.GetAsync(Routing.Products.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var products = await response.GetResponseContent<List<ProductDto>>();
            products.Should().BeEmpty();
        }

        [Fact]
        public async Task Given_GetAll_ReturnsCorrectData()
        {
            var fakeCategory = Category.Create("test", "test");
            var fakeProduct = Product.Create("test", "test", fakeCategory, new FakeCurrentUserService());
            await SeedProduct(fakeProduct);
            var client = await Application.GetAuthenticatedClientAsync();

            var response = await client.GetAsync(Routing.Products.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var products = await response.GetResponseContent<List<ProductDto>>();
            products.Count.Should().Be(1);
            products.First().AssertEquals(fakeProduct, fakeCategory);
        }

        [Fact]
        public async Task Given_Create_Then_ProductsIsSavedInDatabase()
        {
            var fakeCategory = Category.Create("test", "test");
            var createProductRequest = GetFakeCreateProductRequest(fakeCategory);
            await SeedCategory(fakeCategory);
            var client = await Application.GetAuthenticatedClientAsync();

            var response = await client.PostAsync(Routing.Products.Create, createProductRequest);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await EnsureProductWasSaved(createProductRequest.Name);
        }

        [Fact]
        public async Task Given_Delete_Then_ProductIsDeleted()
        {
            var fakeCategory = Category.Create("test", "test");
            var fakeProduct = Product.Create("test", "test", fakeCategory, new FakeCurrentUserService());
            await SeedProduct(fakeProduct);
            var client = await Application.GetAuthenticatedClientAsync();
            var url = Routing.Products.Delete(fakeProduct.Id);

            var response = await client.DeleteAsync(url);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            await EnsureProductWasDeleted(fakeProduct.Id);
        }
    }
}
