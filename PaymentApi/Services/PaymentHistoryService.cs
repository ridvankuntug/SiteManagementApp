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
            _paymentHistoryModel.Find(history => true).ToList();

        public PaymentHistoryModel Get(string id) =>
            _paymentHistoryModel.Find<PaymentHistoryModel>(history => history.PaymentId == id).FirstOrDefault();

        public List<PaymentHistoryModel> GetByCardNumber(int cardNumber) =>
            _paymentHistoryModel.Find<PaymentHistoryModel>(history => history.CardNumber == cardNumber).ToList();

        public PaymentHistoryModel Create(PaymentHistoryModel history)
        {
            _paymentHistoryModel.InsertOne(history);
            return history;
        }

        public void Update(string id, PaymentHistoryModel historyIn) =>
            _paymentHistoryModel.ReplaceOne(history => history.PaymentId == id, historyIn);

        public void Remove(PaymentHistoryModel historyIn) =>
            _paymentHistoryModel.DeleteOne(history => history.PaymentId == historyIn.PaymentId);

        public void Remove(string id) =>
            _paymentHistoryModel.DeleteOne(history => history.PaymentId == id);
    }
}
