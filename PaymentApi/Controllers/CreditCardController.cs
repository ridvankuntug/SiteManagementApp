using Microsoft.AspNetCore.Mvc;
using PaymentApi.Model;
using PaymentApi.Services;
using System.Collections.Generic;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public ActionResult<List<CreditCardModel>> Get() =>
            _creditCardService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCreditCard")]
        public ActionResult<CreditCardModel> Get(string id)
        {
            var card = _creditCardService.Get(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        [HttpPost]
        public ActionResult<CreditCardModel> Create(CreditCardModel card)
        {
            _creditCardService.Create(card);

            return CreatedAtRoute("GetCreditCard", new { id = card.CardId.ToString() }, card);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CreditCardModel cardIn)
        {
            var card = _creditCardService.Get(id);

            if (card == null)
            {
                return NotFound();
            }

            _creditCardService.Update(id, cardIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var card = _creditCardService.Get(id);

            if (card == null)
            {
                return NotFound();
            }

            _creditCardService.Remove(card.CardId);

            return NoContent();
        }
    }
}
