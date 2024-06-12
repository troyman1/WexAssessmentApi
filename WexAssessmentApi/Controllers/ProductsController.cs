using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WexAssessmentApi.Models;
using WexAssessmentApi.Repositories;

namespace WexAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly ProductContext _context;
        private readonly ProductRepository<Product> _products;

        //public ProductsController(ProductContext context)
        //{
        //    _context = context;
        //}

        public ProductsController(ProductRepository<Product> products)
        {
            _products = products;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_products == null)
            {
                return NotFound();
            }

            var products = await _products.GetAllAsync();

            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_products == null)
            {
                return NotFound();
            }
            var product = await _products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            //_context.Entry(product).State = EntityState.Modified;

            //try
            //{
            //    await _products.UpdateAsync(product);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            await _products.UpdateAsync(product);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_products == null)
            {
                return Problem("Entity set 'ProductContext.Products'  is null.");
            }
            await _products.AddAsync(product);
            //await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_products == null)
            {
                return NotFound();
            }
            var product = await _products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _products.DeleteAsync(id);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool ProductExists(int id)
        //{
        //    return (_products?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
