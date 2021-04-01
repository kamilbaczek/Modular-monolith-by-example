using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using Divstack.Company.Estimation.Tool.Products.DAL;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Products.IntegrationsTests
{
    public abstract class ProductsModuleIntegrationTest : IntegrationTest<ProductsContext>
    {
        protected async Task SeedProduct(Product fakeProduct)
        {
            await Application.ExecuteOnDatabaseContextAsync<ProductsContext>(async context =>
            {
                await context.Products.AddAsync(fakeProduct);
                await context.SaveChangesAsync();
            });
        }

        protected async Task SeedCategory(Category fakeCategory)
        {
            await Application.ExecuteOnDatabaseContextAsync<ProductsContext>(async context =>
            {
                await context.Categories.AddAsync(fakeCategory);
                await context.SaveChangesAsync();
            });
        }

        protected async Task EnsureProductWasSaved(string name)
        {
            await Application.ExecuteOnDatabaseContextAsync<ProductsContext>(async context =>
            {
                var product = await context.Products.SingleOrDefaultAsync(product => product.Name == name);
                product.Should().NotBeNull();
            });
        }

        protected async Task EnsureProductWasDeleted(Guid id)
        {
            await Application.ExecuteOnDatabaseContextAsync<ProductsContext>(async context =>
            {
                var product = await context.Products.SingleOrDefaultAsync(product => product.Id == id);
                product.Should().BeNull();
            });
        }

        protected static CreateProductRequest GetFakeCreateProductRequest(Category fakeCategory)
        {
            var createProductRequest = new CreateProductRequest
            {
                Description = "test",
                Name = "Test",
                CategoryId = fakeCategory.Id
            };

            return createProductRequest;
        }
    }
}
