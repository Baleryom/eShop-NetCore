using eShop.Api.Interfaces;
using eShop.Domain.Models;
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

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
           var addResult = _seeder.AddProduct(product);
            if (!addResult)
                return BadRequest("Product was not added");
            else
                return Created("https://localhost:5001/api/products/{product.Id}",product.Id);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromBody] Product updatedProduct, int id)
        {
           var updateResult = _seeder.UpdateProduct(id, updatedProduct);

            if (updateResult) 
            return Ok("Product was updated succesfully!");

            return BadRequest("Could't update product. Please try again!");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteResult = _seeder.DeleteProduct(id);

            if (deleteResult)
                return Ok("Product was deleted!");

            return BadRequest("Can't delete product. Try again later!");
        }

    }
}
