using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BeSpokedDataContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(BeSpokedDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            return await _context.Customers
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public void CreateCustomer(CustomerDto customer)
        {
            _context.Entry(_mapper.Map<Customer>(customer)).State = EntityState.Added;
        }
    }
}