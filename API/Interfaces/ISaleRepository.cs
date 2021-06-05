using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ISaleRepository
    {
         Task<IEnumerable<SaleDto>> GetSalesAsync(SalesParams salesParams);
         Task CreateSaleAsync(SaleDto sale);
         void DeleteSale(Sale sale);
         Task<Sale> GetSale(int id);
    }
}