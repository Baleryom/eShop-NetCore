using eShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace eShop.Api.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        public ProductsController()
        {

        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var product = new Product();
            product.Id = 1;
            product.Name = "Camera";
            product.Price = 12.99f;

            return Ok(product);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = new Product();
            product.Id = id;
            product.Name = "Camera";
            product.Price = 12.99f;

            return Ok(product);
        }

    }
}
