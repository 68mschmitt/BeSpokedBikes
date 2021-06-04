using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DiscountsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> GetDiscounts()
        {
            return Ok(await _unitOfWork.DiscountRepository.GetDiscountsAsync());
        }
    }
}