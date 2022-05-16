using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardRepository _creditCardRepo;

        public CreditCardController(ICreditCardRepository creditCardRepo)
        {
            _creditCardRepo = creditCardRepo;
        }

        [HttpGet]
        [Route("/api/[controller]/{creditCardId}", Name = "GetCreditCard")]
        public IActionResult GetCreditCard(int creditCardId)
        {
            var result = _creditCardRepo.Get(creditCardId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertCreditCard(CreditCardModel creditCardModel)
        {
            if (ModelState.IsValid)
            {
                CreditCard creditCard = new CreditCard
                {
                    Number = creditCardModel.Number,
                    ExpDate = creditCardModel.ExpDate,
                    SVC = creditCardModel.SVC,
                    BillingAddress = creditCardModel.BillingAddress,
                    City = creditCardModel.City,
                    State = creditCardModel.State,
                    Zipcode = creditCardModel.Zipcode
                };

                var result = _creditCardRepo.Insert(creditCard);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetCreditCard), new { creditCardId = result.Data.CreditCardId }, result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);

            }
        }

        [HttpDelete("{creditCardId}")]
        public IActionResult DeleteCreditCard(int creditCardId)
        {
            var findResult = _creditCardRepo.Get(creditCardId);
            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _creditCardRepo.Delete(creditCardId);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        [Route("/api/[controller]/")]
        public IActionResult UpdateCreditCard(CreditCardModel creditCardModel)
        {
            if (ModelState.IsValid && creditCardModel.CreditCardId > 0)
            {
                CreditCard creditCard = new CreditCard
                {
                    CreditCardId = creditCardModel.CreditCardId,
                    Number = creditCardModel.Number,
                    ExpDate = creditCardModel.ExpDate,
                    SVC = creditCardModel.SVC,
                    BillingAddress = creditCardModel.BillingAddress,
                    City = creditCardModel.City,
                    State = creditCardModel.State,
                    Zipcode = creditCardModel.Zipcode
                };

                var findResult = _creditCardRepo.Get(creditCard.CreditCardId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _creditCardRepo.Update(creditCard);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (creditCardModel.CreditCardId < 1)
                    ModelState.AddModelError("CreditCardId", "Invalid Credit Card ID");
                return BadRequest(ModelState);
            }
        }
    }
}
