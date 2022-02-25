using MongoDB.Bson;
using PaymentApi.Model;
using System;

namespace PaymentApi.Services
{
    public class PaymentService
    {

        public readonly CreditCardService _creditCardService;
        public readonly PaymentHistoryService _paymentHistoryService;

        public PaymentService(CreditCardService creditCardService, PaymentHistoryService paymentService)
        {
            _creditCardService = creditCardService;
            _paymentHistoryService = paymentService;
        }

        public bool LoadBalance(long cardNumber, float addBalance)
        {
            bool result = _creditCardService.AddBalance(cardNumber, addBalance);
            if (result)
            {
                CreditCardModel cardObj = _creditCardService.GetByCardNumber(cardNumber);
                cardObj.Balance = cardObj.Balance - addBalance;
                _creditCardService.UpdateByCardNumber(cardNumber, cardObj);

                PaymentHistoryModel historyObj = new PaymentHistoryModel();
                historyObj.CardNumber = cardNumber;
                historyObj.Amount = addBalance;
                historyObj.TransactionTime = DateTime.Now;

                historyObj.Description =
                    cardObj.OwnerName + ", " +
                    DateTime.Now + " tarihinde, " +
                    cardNumber + " numaralı kartna, " +
                    addBalance + "₺ miktarında YÜKLEME yapmıştır.";

                _paymentHistoryService.Create(historyObj);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Pay(long cardNumber, int exYear, int exMonth, int ccv, float debt)
        {
            bool checkCard = _creditCardService.CheckCardDetails(cardNumber, exYear, exMonth, ccv, debt);
            if (checkCard)
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
                    debt + "₺ miktarında ÖDEMESİNİ yapmıştır.";

                _paymentHistoryService.Create(historyObj);
                return true;
            }
            else { return false; }
        }
    }
}
