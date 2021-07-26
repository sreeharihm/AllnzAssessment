using MongoDB.Driver;
using System;

namespace GatewayApi.Background.Extensions
{
    public static class MongoDbExtensions
    {
        public static void CreateCollecitonIfNotExist(this IMongoDatabase database)
        {
            try
            {
                database.CreateCollection("Product");
                database.CreateCollection("PriceReduction");
            }
            catch (Exception)
            {
                //No need to log the error
            }
        }
    }
}
