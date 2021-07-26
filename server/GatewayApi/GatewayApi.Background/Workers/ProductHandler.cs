using EasyNetQ;
using GatewayApi.Background.Factories;
using GatewayApi.Background.Interfaces;
using GatewayApi.Background.Messages;
using GatewayApi.Background.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GatewayApi.Background.Workers
{
    public class ProductHandler : BackgroundService
    {
        private readonly IBus _bus;
        private readonly IProductService _productServices;
        public ProductHandler(IBus iBus, IProductService productServices)
        {
            _bus = iBus;
            _productServices = productServices;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.Rpc.RespondAsync<ProductsRequest, ProductsResponse>(new ProductFactory(_productServices).GetProduct);
        }
    }
}
