using eShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

        //Entities
        public DbSet<Product> Products { get; set; }
    }
}
