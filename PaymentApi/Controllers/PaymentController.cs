using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;

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

        [HttpGet("{cardNumber}/{exYear}/{exMonth}/{ccv}/{debt}", Name = "Pay")]
        public bool Pay(int cardNumber, int exYear, int exMonth, int ccv, float debt)
        {
            bool result = _paymentService.Pay(cardNumber, exYear, exMonth, ccv, debt);
            return result; 
        }
    }
}
