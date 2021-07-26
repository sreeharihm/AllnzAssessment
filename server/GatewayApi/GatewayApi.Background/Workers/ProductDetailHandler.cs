using EasyNetQ;
using GatewayApi.Background.Factories;
using GatewayApi.Background.Interfaces;
using GatewayApi.Background.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace GatewayApi.Background.Workers
{
    public class ProductDetailHandler : BackgroundService
    {
        private readonly IBus _bus;
        private readonly IProductService _productServices;
        private readonly IConfiguration _configuration;
        public ProductDetailHandler(IBus bus, IProductService productServices,IConfiguration configuration)
        {
            _bus = bus;
            _productServices = productServices;
            _configuration = configuration;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.Rpc.RespondAsync<ProductDetailsRequest, ProductDetailsResponse>(new ProductFactory(_productServices).GetProductDetails);
        }
    }
}
