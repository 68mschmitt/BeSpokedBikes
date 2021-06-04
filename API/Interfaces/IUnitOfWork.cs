using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
         ICustomerRepository CustomerRepository { get; }
         IDiscountRepository DiscountRepository { get; }
         IProductRepository ProductRepository { get; }
         ISaleRepository SaleRepository { get; }
         ISalesPersonRepository SalesPersonRepository { get; }
         Task<bool> Complete();
         bool HasChanges();
    }
}