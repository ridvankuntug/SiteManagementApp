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

        public PaymentHistoryController(PaymentHistoryService paymentService)
        {
            _paymentHistoryService = paymentService;
        }

        [HttpGet]
        public ActionResult<List<PaymentHistoryModel>> Get() =>
            _paymentHistoryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPaymentHistory")]
        public ActionResult<PaymentHistoryModel> Get(string id)
        {
            var pay = _paymentHistoryService.Get(id);

            if (pay == null)
            {
                return NotFound();
            }

            return pay;
        }

        [HttpPost]
        public ActionResult<PaymentHistoryModel> Create(PaymentHistoryModel pay)
        {
            _paymentHistoryService.Create(pay);

            return CreatedAtRoute("GetPaymentHistory", new { id = pay.PaymentId.ToString() }, pay);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PaymentHistoryModel payIn)
        {
            var pay = _paymentHistoryService.Get(id);

            if (pay == null)
            {
                return NotFound();
            }

            _paymentHistoryService.Update(id, payIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var pay = _paymentHistoryService.Get(id);

            if (pay == null)
            {
                return NotFound();
            }

            _paymentHistoryService.Remove(pay.PaymentId);

            return NoContent();
        }
    }
}
