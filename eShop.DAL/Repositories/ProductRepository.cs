using eShop.Domain.Interfaces;
using eShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _context;
        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
             _context.Products.Add(product);
             await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
           return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<bool> UpdateProductAsync(Product updatedProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);
            product.Name = updatedProduct.Name;
            product.PhotoUrl = updatedProduct.PhotoUrl;
            product.Price = updatedProduct.Price;
            product.Supplier = updatedProduct.Supplier;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
