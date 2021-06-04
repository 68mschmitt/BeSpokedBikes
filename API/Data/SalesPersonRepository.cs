using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private readonly BeSpokedDataContext _context;
        private readonly IMapper _mapper;
        public SalesPersonRepository(BeSpokedDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateSalesPersonAsync(SalesPersonDto salesPerson)
        {
            var existingPerson = await GetSalesPersonByNameAsync(salesPerson.FirstName + salesPerson.LastName);
            if (existingPerson == null) _context.Entry(_mapper.Map<SalesPerson>(salesPerson)).State = EntityState.Added;
        }
        public async Task<SalesPerson> GetSalesPersonByNameAsync(string fullName)
        {
            return await _context.SalesPeople.SingleOrDefaultAsync(sp => (sp.FirstName + sp.LastName) == fullName);
        }

        public async Task<IEnumerable<SalesPerson>> GetSalesPeopleAsync()
        {
            var salesPeople = await _context.SalesPeople.ToListAsync();

            return salesPeople;
        }

        public async Task<SalesPerson> GetSalesPersonAsync(int Id)
        {
            var salesPerson = await _context.SalesPeople.FindAsync(Id);

            return salesPerson;
        }
        public void UpdateSalesPerson(SalesPerson person)
        {
            _context.Entry(person).State = EntityState.Modified;
        }
    }
}