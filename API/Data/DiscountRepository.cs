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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly BeSpokedDataContext _context;
        private readonly IMapper _mapper;
        public DiscountRepository(BeSpokedDataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscountsAsync()
        {
            var discounts = await _context.Discounts
                .Include(p => p.Product)
                .ProjectTo<DiscountDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return discounts;
        }
    }
}