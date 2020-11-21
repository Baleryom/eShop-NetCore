using eShop.Api.Interfaces;
using eShop.Domain.Models;
using System.Collections.Generic;

namespace eShop.Api.Services
{
    public class Seeder : ISeeder
    {
        private List<Product> _products = new List<Product>();
        public List<Product> GetAllProducts()
        {
            var product1 = new Product
            {
                Id = 1,
                Name = "Camera",
                Description = "Good resoulution",
                Price = 34.89f
            };
            _products.Add(product1);
            var product2 = new Product
            {
                Id = 2,
                Name = "Microphone",
                Description = "Good quality",
                Price = 56.10f
            };
            _products.Add(product2);

            return _products;
        }
    }
}
