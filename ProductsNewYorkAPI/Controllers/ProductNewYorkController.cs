using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsNewYorkAPI.Data;
using ProductsNewYorkAPI.Models;

namespace ProductsNewYorkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductNewYorkController : ControllerBase
    {
        private readonly ProductsNewYorkDbContext context;

        public ProductNewYorkController(ProductsNewYorkDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductNewYork>>> GetProductsNewYork()
        {
            return Ok(await context.ProductsNewYork.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductNewYork>> GetProductNewYorkById(int id) 
        {
            ProductNewYork? productNewYork = await context.ProductsNewYork.FindAsync(id);
            if (productNewYork is null)
            {
                return NotFound("Product not found in products New York");
            }
            return Ok(productNewYork);
        }

        [HttpPost]
        public async Task<ActionResult<ProductNewYork>> PostProductNewYork(ProductNewYorkDto productNewYorkDto)
        {
            ProductNewYork productNewYork = new ProductNewYork()
            {
                Name = productNewYorkDto.Name,
                Description = productNewYorkDto.Description
            };
            await context.ProductsNewYork.AddAsync(productNewYork);
            await context.SaveChangesAsync();

            return Ok(productNewYork);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductNewYork>> PutProductNewYork(int id, ProductNewYorkDto productNewYorkDto)
        {
            ProductNewYork? productNewYork = await context.ProductsNewYork.FindAsync(id);

            if (productNewYork is null) 
            {
                return NotFound("Product not found in products New York");
            }
            productNewYork.Name = productNewYorkDto.Name;
            productNewYork.Description = productNewYorkDto.Description;

            await context.SaveChangesAsync();
            return Ok(productNewYork);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProductNewYork(int id)
        {
            ProductNewYork? productNewYork = await context.ProductsNewYork.FindAsync(id);
            if (productNewYork is null)
            {
                return NotFound("Product not found in products New York");
            }
            context.ProductsNewYork.Remove(productNewYork);
            await context.SaveChangesAsync();
            return Ok();
        }

            
    }
}
