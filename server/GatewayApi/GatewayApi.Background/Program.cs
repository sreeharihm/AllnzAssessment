using EasyNetQ;
using GatewayApi.Background.Interfaces;
using GatewayApi.Background.Services;
using GatewayApi.Background.Workers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    var rabbConnString = configuration.GetConnectionString("rabbitMq");
                    var bus = RabbitHutch.CreateBus(rabbConnString);
                    services.AddSingleton(bus);
                    services.AddTransient<IProductService,ProductServices>();
                    services.AddHostedService<ProductHandler>();
                    services.AddHostedService<ProductDetailHandler>();
                });
    }
}
