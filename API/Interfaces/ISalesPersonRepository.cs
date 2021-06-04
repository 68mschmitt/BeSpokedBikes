using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISalesPersonRepository
    {
         Task<IEnumerable<SalesPerson>> GetSalesPeopleAsync();
         Task<SalesPerson> GetSalesPersonAsync(int Id);
         void UpdateSalesPerson(SalesPerson person);
         Task CreateSalesPersonAsync(SalesPersonDto salesPerson);
         Task<SalesPerson> GetSalesPersonByNameAsync(string fullName);
    }
}