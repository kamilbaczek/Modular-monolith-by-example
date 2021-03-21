using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Api;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Products.IntegrationsTests
{
    public class ProductsModuleTests : ProductsModuleIntegrationTest
    {
        [Fact]
        public async Task Given_GetAll_WithoutAnyReturnsEmptyResponse()
        {
            await AuthenticateAsync();

            var response = await HttpClient.GetAsync(Routing.Products.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<ProductDto>>()).Should().BeEmpty();
        }

        [Fact]
        public async Task Given_GetAll_ReturnsCorrectData()
        {
            await AuthenticateAsync();

            var response = await HttpClient.GetAsync(Routing.Products.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<ProductDto>>()).Should().BeEmpty();
        }

    }
}
