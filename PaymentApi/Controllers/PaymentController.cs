using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;
using System;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{cardNumber}/{exYear}/{exMonth}/{ccv}/{debt}", Name = "PayDebt")]
        public bool PayDebt(long cardNumber, int exYear, int exMonth, int ccv, float debt, string period)
        {
            //try
            //{
                bool result = _paymentService.Pay(cardNumber, exYear, exMonth, ccv, debt, period);
                return result;
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new InvalidOperationException(ex.Message));
            //}
        }

        [HttpPost("{cardNumber}/{addBalance}", Name = "AddBalance")]
        public bool AddBalanceToCard(long cardNumber, float addBalance)
        {
            bool result = _paymentService.LoadBalance(cardNumber, addBalance);
            return result;
        }
    }
}
