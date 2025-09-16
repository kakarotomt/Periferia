using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoWebApi.DataLayer;
using proyectoWebApi.DataLayer.Dapper;
using proyectoWebApi.DataLayer.Models;

namespace proyectoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WebApiContext _context;
        private readonly IProductRepository _productRepository;

        public ProductsController(WebApiContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var products = await _productRepository.GetAllAsync(null);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{code}")]
        public async Task<ActionResult<Product>> GetProduct(int code)
        {
            var products = await _productRepository.GetAllAsync(code);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutProduct(Product product)
        {
            if (product == null) return BadRequest();
            var updated = await _productRepository.UpdateAsync(product);
            if (!updated) return NotFound();
            return Ok();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                var newId = await _productRepository.CreateAsync(product);
                product.Id = newId;
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProduct(int code)
        {
            var deleted = await _productRepository.DeleteAsync(code);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
