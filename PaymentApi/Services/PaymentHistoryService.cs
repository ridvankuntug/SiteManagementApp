using MongoDB.Driver;
using PaymentApi.DbSettings;
using PaymentApi.Model;
using System.Collections.Generic;

namespace PaymentApi.Services
{
    public class PaymentHistoryService
    {
        private readonly IMongoCollection<PaymentHistoryModel> _paymentHistoryModel;

        public PaymentHistoryService(IPaymentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _paymentHistoryModel = database.GetCollection<PaymentHistoryModel>(settings.CollectionNamePaymentHistory);
        }

        public List<PaymentHistoryModel> Get() =>
            _paymentHistoryModel.Find(pay => true).ToList();

        public PaymentHistoryModel Get(string id) =>
            _paymentHistoryModel.Find<PaymentHistoryModel>(pay => pay.PaymentId== id).FirstOrDefault();

        public PaymentHistoryModel Create(PaymentHistoryModel pay)
        {
            pay.PaymentId = "";
            _paymentHistoryModel.InsertOne(pay);
            return pay;
        }

        public void Update(string id, PaymentHistoryModel payIn) =>
            _paymentHistoryModel.ReplaceOne(pay => pay.PaymentId == id, payIn);

        public void Remove(PaymentHistoryModel payIn) =>
            _paymentHistoryModel.DeleteOne(pay => pay.PaymentId == payIn.PaymentId);

        public void Remove(string id) =>
            _paymentHistoryModel.DeleteOne(pay => pay.PaymentId == id);
    }
}
