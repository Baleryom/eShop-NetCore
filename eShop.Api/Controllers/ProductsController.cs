using eShop.Api.DTOs;
using eShop.Api.Interfaces;
using eShop.Domain.Interfaces;
using eShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Api.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ISeeder _seeder;
        private readonly IProductRepository _products;
        public ProductsController(IProductRepository products)
        {
            _products = products;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            List<ProductGetDTO> productsDto = new List<ProductGetDTO>();
            var products = await _products.GetAllProductsAsync();

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
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await  _products.GetProductByIdAsync(id);

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
        public async Task<IActionResult> CreateProduct([FromBody] ProductPutPostDTO productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Price = productDto.Price;
           
         
                var addResult = await _products.CreateProductAsync(product);
                if (addResult == null)
                    return BadRequest("Product was not added");
                else
                    return Created("https://localhost:5001/api/products/{product.Id}", product.Id);
            }

            return BadRequest("Model is not valid");
          
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductPutPostDTO updatedProductDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updatedProduct = new Product();
                updatedProduct.Id = id;
                updatedProduct.Name = updatedProductDto.Name;
                updatedProduct.Description = updatedProductDto.Description;
                updatedProduct.PhotoUrl = updatedProductDto.PhotoUrl;
                updatedProduct.Price = updatedProductDto.Price;

                var updateResult = await _products.UpdateProductAsync(updatedProduct);

                if (updateResult)
                    return Ok("Product was updated succesfully!");

                return BadRequest("Could't update product. Please try again!");
            }

            return BadRequest("Model is not valid");
          
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteResult = await _products.DeleteProductAsync(id);

            if (deleteResult)
                return Ok("Product was deleted!");

            return BadRequest("Can't delete product. Try again later!");
        }

    }
}
