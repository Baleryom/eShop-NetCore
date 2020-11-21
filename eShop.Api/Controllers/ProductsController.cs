using eShop.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eShop.Api.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ISeeder _seeder;
        public ProductsController(ISeeder seeder)
        {
            _seeder = seeder;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
          

            return Ok(_seeder.GetAllProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _seeder.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

    }
}
