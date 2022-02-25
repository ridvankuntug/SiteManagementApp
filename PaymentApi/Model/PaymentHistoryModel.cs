using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentApi.Model
{
    public class PaymentHistoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PaymentId { get; set; }

        public long CardNumber { get; set; }
        public double Amount{ get; set; }
        public BsonDateTime TransactionTime { get; set; }

        public string Description { get; set; }
    }
}
