using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SalesPeopleController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalesPeopleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesPerson>>> GetSalesPeople()
        {
            var salesPeople = await _unitOfWork.SalesPersonRepository.GetSalesPeopleAsync();

            if (salesPeople != null) return Ok(salesPeople);

            return NotFound("Sales people not found");
        }

        [HttpGet("get-salesperson/{id}")]
        public async Task<ActionResult<SalesPerson>> GetSalesPersonAsync(int id)
        {
            var salesPerson = await _unitOfWork.SalesPersonRepository.GetSalesPersonAsync(id);

            if (salesPerson != null) return salesPerson;

            return NotFound("Sales person was not found");
        }

        [HttpPost("update-sales-person")]
        public async Task<ActionResult> UpdateSalesPersonAsync(SalesPerson person)
        {
            _unitOfWork.SalesPersonRepository.UpdateSalesPerson(person);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest();
        }
        [HttpPost("create-sales-person")]
        public async Task<ActionResult> CreateSalesPersonAsync(SalesPersonDto salesPerson)
        {
            await _unitOfWork.SalesPersonRepository.CreateSalesPersonAsync(salesPerson);
            if (await _unitOfWork.Complete()) return NoContent();
            return BadRequest("Sales Person Was Not Created");
        }
    }
}