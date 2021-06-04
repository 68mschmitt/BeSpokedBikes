using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.GetProductsAsync();

            if (products != null) return Ok(products);

            return BadRequest("Something went wrong");
        }

        [HttpPost("update-product")]
        public async Task<ActionResult> UpdateProductAsync(Product product)
        {
            _unitOfWork.ProductRepository.UpdateProduct(product);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest();
        }

        [HttpPost("create-product")]
        public async Task<ActionResult<Product>> CreateProductAsync(ProductDto product)
        {
            await _unitOfWork.ProductRepository.CreateProduct(product);
            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest();
        }

        [HttpGet("get-product-by-id")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(id);
            if (product != null) return Ok(product);
            return NotFound($"Product was not found with id ${id}");
        }
    }
}