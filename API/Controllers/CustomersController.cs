using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _unitOfWork.CustomerRepository.GetCustomersAsync();

            return Ok(customers);
        }
        [HttpPost("create-customer")]
        public async Task<ActionResult> CreateCustomer(CustomerDto customer)
        {
            _unitOfWork.CustomerRepository.CreateCustomer(customer);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest();
        }
    }
}