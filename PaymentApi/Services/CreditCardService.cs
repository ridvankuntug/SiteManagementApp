using MongoDB.Driver;
using PaymentApi.DbSettings;
using PaymentApi.Model;
using System;
using System.Collections.Generic;

namespace PaymentApi.Services
{
    public class CreditCardService
    {

        private readonly IMongoCollection<CreditCardModel> _creditCardService;

        public CreditCardService(IPaymentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _creditCardService = database.GetCollection<CreditCardModel>(settings.CollectionNameCreditCard);

            _creditCardService.Indexes.CreateOne(
                  new CreateIndexModel<CreditCardModel>(
                    Builders<CreditCardModel>.IndexKeys.Ascending(d => d.CardNumber),
                    new CreateIndexOptions { Unique = true }
));
        }

        #region Payment servisinde kullanmak için özelleştirilmiş metodlar
        public CreditCardModel GetByCardNumber(int cardNumber) =>
            _creditCardService.Find<CreditCardModel>(card => card.CardNumber == cardNumber).FirstOrDefault();

        public void UpdateByCardNumber(int cardNumber, CreditCardModel cardIn) =>
            _creditCardService.ReplaceOne(card => card.CardNumber == cardNumber, cardIn);

        public void AddBalance(int cardNumber, float addBalance)
        {
            CreditCardModel cardIn = GetByCardNumber(cardNumber);
            cardIn.Balance = cardIn.Balance + addBalance;
            _creditCardService.ReplaceOne(card => card.CardNumber == cardNumber, cardIn);
        }

        public bool CheckCardDetails(int cardNumber, int exYear, int exMonth, int ccv, float debt)
        {
            var card = _creditCardService.Find<CreditCardModel>(card => card.CardNumber == cardNumber).FirstOrDefault();

            if (card is null)
            {
                throw new InvalidOperationException("Kart bulunamadı.");
            }
            else if (card.CardNumber == cardNumber && card.ExYear == exYear && card.ExMonth == exMonth && card.CCV == ccv)
            {
                if (card.Balance > debt)
                {
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Bakiye yetersiz.");
                }
            }
            else
            {
                throw new InvalidOperationException("Kart bilgileri eşleşmiyor, tekrar kontrol ediniz.");
            }
        }
        #endregion


        public List<CreditCardModel> Get() =>
            _creditCardService.Find(card => true).ToList();

        public CreditCardModel Get(string id) =>
            _creditCardService.Find<CreditCardModel>(card => card.CardId == id).FirstOrDefault();


        public CreditCardModel Create(CreditCardModel card)
        {
            try
            {
                card.CardId = "";
                _creditCardService.InsertOne(card);
                return card;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public void Update(string id, CreditCardModel cardIn) =>
            _creditCardService.ReplaceOne(card => card.CardId == id, cardIn);

        public void Remove(CreditCardModel cardIn) =>
            _creditCardService.DeleteOne(card => card.CardId == cardIn.CardId);

        public void Remove(string id) =>
            _creditCardService.DeleteOne(card => card.CardId == id);
    }
}
