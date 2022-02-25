using MongoDB.Bson;
using PaymentApi.Model;
using System;

namespace PaymentApi.Services
{
    public class PaymentService
    {

        private readonly CreditCardService _creditCardService;
        private readonly PaymentHistoryService _paymentHistoryService;

        public PaymentService(CreditCardService creditCardService, PaymentHistoryService paymentService)
        {
            _creditCardService = creditCardService;
            _paymentHistoryService = paymentService;
        }

        public bool Pay(int cardNumber, int exYear, int exMonth, int ccv, float debt)
        {
            bool checkCard = _creditCardService.CheckCardDetails(cardNumber, exYear, exMonth, ccv, debt);
            if (checkCard)
            {
                try
                {
                    CreditCardModel cardObj = _creditCardService.GetByCardNumber(cardNumber);
                    cardObj.Balance = cardObj.Balance - debt;
                    _creditCardService.UpdateByCardNumber(cardNumber, cardObj);

                    PaymentHistoryModel historyObj = new PaymentHistoryModel();
                    historyObj.CardNumber = cardNumber;
                    historyObj.Amount = debt;
                    historyObj.TransactionTime = DateTime.Now;

                    historyObj.Description =
                        cardObj.OwnerName + ", " +
                        DateTime.Now + " tarihinde, " +
                        cardNumber + " numaralı kartı ile, " +
                        exMonth + "/" + exYear + " Döneminin, " +
                        debt + "₺ miktarında ödemsini yapmıştır.";

                    _paymentHistoryService.Create(historyObj);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
            }
            else { return false; }

        }
    }
}
