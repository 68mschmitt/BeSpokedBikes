using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly BeSpokedDataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(BeSpokedDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateProduct(ProductDto product)
        {
            var existingProduct = await GetProductByNameAsync(product.Name);
            // We want a number between 0 and 100. If the user puts in something else than they will be adjusted
            if (product.CommissionPercentage < 0) product.CommissionPercentage = 0;
            else if (product.CommissionPercentage > 100) product.CommissionPercentage = 100;
            if (existingProduct == null) _context.Entry(_mapper.Map<Product>(product)).State = EntityState.Added;;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Name == name);
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public void UpdateProduct(Product product)
        {
            // We want a number between 0 and 100. If the user puts in something else than they will be adjusted
            if (product.CommissionPercentage < 0) product.CommissionPercentage = 0;
            else if (product.CommissionPercentage > 100) product.CommissionPercentage = 100;
            _context.Entry(product).State = EntityState.Modified;
        }
    }
}