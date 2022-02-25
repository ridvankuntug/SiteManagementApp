using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentApi.Model
{
    public class CreditCardModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CardId { get; set; }

        [BsonElement("Name")]
        public string OwnerName { get; set; }
        public long CardNumber { get; set; }
        public int ExYear { get; set; }
        public int ExMonth { get; set; }
        public int CCV { get; set; }
        public float Balance { get; set; }
    }
}
