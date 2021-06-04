using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly BeSpokedDataContext _context;
        public DiscountRepository(BeSpokedDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discount>> GetDiscountsAsync()
        {
            var discounts = await _context.Discounts.Include(p => p.Product).ToListAsync();

            return discounts;
        }
    }
}