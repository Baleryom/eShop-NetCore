using eShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>>  GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product updatedProduct);
        Task<bool> DeleteProductAsync(int product);
    }
}
