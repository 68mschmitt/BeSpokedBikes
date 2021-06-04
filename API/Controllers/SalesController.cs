using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SalesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesAsync([FromQuery] SalesParams salesParams)
        {
            var sales = await _unitOfWork.SaleRepository.GetSalesAsync(salesParams);

            if (sales != null) return Ok(sales);

            return NotFound("There were no sales found");
        }

        [HttpPost]
        public async Task<ActionResult> CreateSaleAsync(SaleDto sale)
        {
            await _unitOfWork.SaleRepository.CreateSaleAsync(sale);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest();
        }

        [HttpPost("remove-sale")]
        public async Task<ActionResult> RemoveSale(int id)
        {
            _unitOfWork.SaleRepository.DeleteSale(await _unitOfWork.SaleRepository.GetSale(id));

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest();
        }
    }
}