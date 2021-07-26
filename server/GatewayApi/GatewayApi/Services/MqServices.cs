
using EasyNetQ;
using GatewayApi.Background.Messages;
using GatewayApi.Interface;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GatewayApi.Services
{
    public class MqServices : IMqService
    {
        private readonly IConfiguration _configuration;
        private readonly IBus _bus;
        public MqServices(IConfiguration configuration)
        {
            _configuration = configuration;
            var rabbConnString = _configuration.GetConnectionString("rabbitMq");// "host=localhost;timeout=120;virtualHost=/;username=guest;password=guest";
            _bus = RabbitHutch.CreateBus(rabbConnString);
        }
        public async  Task<ProductDetailsResponse> GetProductDetails(string id)
        {
            var request = new ProductDetailsRequest();
            request.ProductId = id;
            return await _bus.Rpc.RequestAsync<ProductDetailsRequest, ProductDetailsResponse>(request);
        }

        public async Task<ProductsResponse> GetProducts()
        {
            var request = new ProductsRequest();
            return await _bus.Rpc.RequestAsync<ProductsRequest, ProductsResponse>(request);
        }
    }
}
