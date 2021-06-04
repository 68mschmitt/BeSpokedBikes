using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByNameAsync(string name);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task CreateProduct(ProductDto product);
        void UpdateProduct(Product product);
    }
}