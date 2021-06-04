using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<CustomerDto>> GetCustomersAsync();
         Task<Customer> GetCustomerAsync(int id);
         void CreateCustomer(CustomerDto customer);
    }
}