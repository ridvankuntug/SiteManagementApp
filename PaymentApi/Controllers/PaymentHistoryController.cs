using Microsoft.AspNetCore.Mvc;
using PaymentApi.Model;
using PaymentApi.Services;
using System.Collections.Generic;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentHistoryController : ControllerBase
    {
        private readonly PaymentHistoryService _paymentHistoryService;

        public PaymentHistoryController(PaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        [HttpGet]
        public ActionResult<List<PaymentHistoryModel>> Get() =>
            _paymentHistoryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPaymentHistory")]
        public ActionResult<PaymentHistoryModel> Get(string id)
        {
            var history = _paymentHistoryService.Get(id);

            if (history == null)
            {
                return NotFound();
            }

            return history;
        }

        [HttpGet("{cardNumber}", Name = "GetByCardNumber")]
        public ActionResult<List<PaymentHistoryModel>> GetByCardNumber(int cardNumber)
        {
            var history = _paymentHistoryService.GetByCardNumber(cardNumber);

            if (history == null)
            {
                return NotFound();
            }

            return history;
        }

        [HttpPost]
        public ActionResult<PaymentHistoryModel> Create(PaymentHistoryModel history)
        {
            _paymentHistoryService.Create(history);

            return CreatedAtRoute("GetPaymentHistory", new { id = history.PaymentId.ToString() }, history);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PaymentHistoryModel historyIn)
        {
            var history = _paymentHistoryService.Get(id);

            if (history == null)
            {
                return NotFound();
            }

            _paymentHistoryService.Update(id, historyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var history = _paymentHistoryService.Get(id);

            if (history == null)
            {
                return NotFound();
            }

            _paymentHistoryService.Remove(history.PaymentId);

            return NoContent();
        }
    }
}
