using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]   
        [Route("/api/[controller]/{customerId}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int customerId)
        {
            var result = _customerRepo.Get(customerId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/email/{email}", Name = "GetCustomerByEmail")]
        public IActionResult GetCustomerByEmail(string email)
        {
            var result = _customerRepo.GetCustomerByEmail(email);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/loginId/{loginId}", Name = "GetCustomerByLoginId")]
        public IActionResult GetCustomerByLoginId(int loginId)
        {
            var result = _customerRepo.GetCustomerByLoginId(loginId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/productcustomer/{id}", Name = "GetCustomerByProduct")]
        public IActionResult GetProductByCustomer(int id)
        {
            var product = _customerRepo.GetCustomerByProduct(id);
            if (!product.Success)
            {
                return BadRequest(product.Message);
            }
            return Ok(product.Data.Select(p => new CustomerModel()
            {
                CustomerId = p.CustomerId,                
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                CreditCardId = p.CreditCardId,
                LoginId = p.LoginId
            }));
        }


        [HttpPost]
        public IActionResult InsertCustomer(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.LastName,
                    Email = customerModel.Email,
                    Phone = customerModel.Phone,
                    CreditCardId = customerModel.CreditCardId,
                    LoginId = customerModel.LoginId
                };

                var result = _customerRepo.Insert(customer);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetCustomer), new { loginId = result.Data.LoginId, creditCardId = result.Data.CreditCardId, customerId = result.Data.CustomerId }, result.Data);
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

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            var findResult = _customerRepo.Get(customerId);
            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _customerRepo.Delete(customerId);

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
        public IActionResult UpdateCustomer(CustomerModel customerModel)
        {
            if (ModelState.IsValid && customerModel.CustomerId > 0)
            {
                Customer customer = new Customer
                {
                    CustomerId = customerModel.CustomerId,
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.LastName,
                    Email = customerModel.Email,
                    Phone = customerModel.Phone,
                    CreditCardId = customerModel.CreditCardId,
                    LoginId = customerModel.LoginId
                };

                var findResult = _customerRepo.Get(customer.CustomerId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _customerRepo.Update(customer);
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
                if (customerModel.CustomerId < 1)
                    ModelState.AddModelError("CustomerId", "Invalid Customer ID");
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/", Name = "GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepo.GetAll();
            if (!customers.Success)
            {
                return BadRequest(customers.Message);
            }
            return Ok(customers.Data.Select(c => new CustomerModel()
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                CreditCardId = c.CreditCardId,
                LoginId = c.LoginId
            }));
        }
    }
}
