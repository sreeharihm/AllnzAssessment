using GatewayApi.Background.Entites;
using MongoDB.Bson;
using System.Collections.Generic;

namespace GatewayApi.Background.Interfaces
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(ObjectId id);
        Product Create(Product product);
        double GetReducionRate(int DayOfWeek);

    }
}
