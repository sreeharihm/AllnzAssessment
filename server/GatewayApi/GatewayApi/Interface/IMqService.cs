
using GatewayApi.Background.Messages;
using System.Threading.Tasks;

namespace GatewayApi.Interface
{
    public interface IMqService
    {
         Task<ProductsResponse> GetProducts();
        Task<ProductDetailsResponse> GetProductDetails(string id);
    }
}
