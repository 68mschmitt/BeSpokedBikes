using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class SaleRepository : ISaleRepository
    {
        private readonly BeSpokedDataContext _context;
        private readonly IMapper _mapper;
        public SaleRepository(BeSpokedDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateSaleAsync(SaleDto sale)
        {
            var newSale = _mapper.Map<Sale>(sale);
            newSale.Customer = await _context.Customers.FindAsync(sale.CustomerId);
            newSale.Product = await _context.Products.FindAsync(sale.ProductId);
            newSale.SalesPerson = await _context.SalesPeople.FindAsync(sale.SalesPersonId);

            _context.Entry(newSale).State = EntityState.Added;
        }

        public void DeleteSale(Sale sale)
        {
            _context.Sales.Remove(sale);
        }

        public async Task<Sale> GetSale(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<IEnumerable<SaleDto>> GetSalesAsync(SalesParams salesParams)
        {
            var query = _context.Sales
                .Include(s => s.SalesPerson)
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .AsQueryable();

            query = salesParams.FilterBy switch
            {
                "product-desc" => query.OrderByDescending(s => s.Product.Name),
                "price-desc" => query.OrderByDescending(s => s.Product.SalePrice),
                "sales-person-desc" => query.OrderByDescending(s => s.SalesPerson.FirstName + s.SalesPerson.LastName),
                "customer-desc" => query.OrderByDescending(s => s.Customer.FirstName + s.Customer.LastName),
                "date-desc" => query.OrderByDescending(s => s.SaleDate),
                "product-asc" => query.OrderBy(s => s.Product.Name),
                "price-asc" => query.OrderBy(s => s.Product.SalePrice),
                "sales-person-asc" => query.OrderBy(s => s.SalesPerson.FirstName + s.SalesPerson.LastName),
                "customer-asc" => query.OrderBy(s => s.Customer.FirstName + s.Customer.LastName),
                "date-asc" => query.OrderBy(s => s.SaleDate),
                _ => query.OrderByDescending(s => s.SaleDate)
            };
            
            return await query.ProjectTo<SaleDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}