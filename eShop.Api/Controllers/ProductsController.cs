using eShop.Api.DTOs;
using eShop.Api.Interfaces;
using eShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            List<ProductGetDTO> productsDto = new List<ProductGetDTO>();
            var products = _seeder.GetAllProducts();

            foreach (var product in products)
            {
                var dto = new ProductGetDTO();
                dto.Id = product.Id;
                dto.Name = product.Name;
                dto.Description = product.Description;
                dto.Price = product.Price;
                dto.Supplier = product.Supplier;
                dto.PhotoUrl = product.PhotoUrl;
               
                productsDto.Add(dto);
               
            } 

            return Ok(productsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _seeder.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            var productDto = new ProductGetDTO();
            productDto.Id = product.Id;
            productDto.Name = product.Name;
            productDto.Description = product.Description;
            productDto.Price = product.Price;
            productDto.Supplier = product.Supplier;
            product.PhotoUrl = product.PhotoUrl;

            return Ok(productDto);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductPutPostDTO productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Price = productDto.Price;
                product.Id = 3;
                product.Supplier = new Supplier();
                product.PhotoUrl = "monekyImage.png";

                var addResult = _seeder.AddProduct(product);
                if (!addResult)
                    return BadRequest("Product was not added");
                else
                    return Created("https://localhost:5001/api/products/{product.Id}", product.Id);
            }

            return BadRequest("Model is not valid");
          
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromBody] ProductPutPostDTO updatedProductDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updatedProduct = new Product();
                updatedProduct.Id = id;
                updatedProduct.Name = updatedProductDto.Name;
                updatedProduct.Description = updatedProductDto.Description;

                var updateResult = _seeder.UpdateProduct(updatedProduct);

                if (updateResult)
                    return Ok("Product was updated succesfully!");

                return BadRequest("Could't update product. Please try again!");
            }

            return BadRequest("Model is not valid");
          
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
