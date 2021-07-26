using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GatewayApi.Background.Entites
{
    public class PriceReduction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}
