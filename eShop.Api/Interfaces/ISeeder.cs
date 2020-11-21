using eShop.Domain.Models;
using System.Collections.Generic;

namespace eShop.Api.Interfaces
{
    public interface ISeeder
    {
        List<Product> GetAllProducts();
        bool AddProduct(Product product);
        bool UpdateProduct(int id, Product updatedProduct);
        bool DeleteProduct(int id);
    }
}
