using eShop.Domain.Models;
using System.Collections.Generic;

namespace eShop.Api.Interfaces
{
    public interface ISeeder
    {
        List<Product> GetAllProducts();
    }
}
