using GatewayApi.Controllers;
using GatewayApi.Interface;
using GatewayApi.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GatewayApi.Test
{
    public class ProductTest
    {
        public readonly IMqService mockService;
        public ProductTest() {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
            mockService = new MqServices(configuration);
        }

        [Fact]
        public async Task Case1()
        {           
            
            ProductController product = new ProductController(mockService);
            Assert.NotNull(await product.Get());
        }
        [Fact]
        public async Task Case2()
        {
            ProductController product = new ProductController(mockService);
            Assert.NotNull(await product.GetProductDetail("60fe57b1ba3e1d54165a05dc"));
        }
        [Fact]
        public async Task Case3()
        {
            ProductController product = new ProductController(mockService);
            var result = await product.GetProductDetail("60fe57b1ba3e1d54165a05dc");
            var id = result.Value.Product.Id;
            Assert.Equal("60fe57b1ba3e1d54165a05dc", id);
        }
        [Fact]
        public async Task Case4()
        {
            ProductController product = new ProductController(mockService);
            var result = await product.GetProductDetail("123456");
            Assert.Null(result.Value);
        }
    }
}
