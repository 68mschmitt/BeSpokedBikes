using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly BeSpokedDataContext _context;
        public UnitOfWork(BeSpokedDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICustomerRepository CustomerRepository => new CustomerRepository(_context, _mapper);

        public IDiscountRepository DiscountRepository => new DiscountRepository(_context);

        public IProductRepository ProductRepository => new ProductRepository(_context, _mapper);

        public ISaleRepository SaleRepository => new SaleRepository(_context, _mapper);

        public ISalesPersonRepository SalesPersonRepository => new SalesPersonRepository(_context, _mapper);

        public IReportRepository ReportRepository => new ReportRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}