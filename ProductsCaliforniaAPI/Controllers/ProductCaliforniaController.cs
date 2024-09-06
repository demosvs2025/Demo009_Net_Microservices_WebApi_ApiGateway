using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCaliforniaAPI.Data;
using ProductsCaliforniaAPI.Models;
using System.Drawing;

namespace ProductsCaliforniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCaliforniaController : ControllerBase
    {
        private readonly ProductsCaliforniaDbContext context;

        public ProductCaliforniaController(ProductsCaliforniaDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCalifornia>>> GetProductsCalifornia()
        {
            return Ok(await context.ProductsCalifornia.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCalifornia>> Get(int id)
        {
            ProductCalifornia? productCalifornia = await context.ProductsCalifornia.FindAsync(id);

            if (productCalifornia is null)
            {
                return NotFound("Product not found in products from California.");
            }

            return Ok(productCalifornia);
        }

        //public ActionResult Post([FromBody] ProductCaliforniaDto productCaliforniaDto)

        [HttpPost]
        public async Task<ActionResult> Post(ProductCaliforniaDto productCaliforniaDto)
        {
            ProductCalifornia productCalifornia = new ProductCalifornia()
            { 
                ProductName = productCaliforniaDto.ProductName,
                Description = productCaliforniaDto.Description,
                Color = productCaliforniaDto.Color
            };
            await context.ProductsCalifornia.AddAsync(productCalifornia);
            await context.SaveChangesAsync();

            return Ok(productCalifornia);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ProductCaliforniaDto productCaliforniaDto)
        {
            ProductCalifornia? productCalifornia = await context.ProductsCalifornia.FindAsync(id);

            if (productCalifornia is null)
            {
                return NotFound("Product not found in products from California.");
            }

            productCalifornia.ProductName = productCaliforniaDto.ProductName;
            productCalifornia.Description = productCaliforniaDto.Description;
            productCalifornia.Color = productCaliforniaDto.Color;

            await context.SaveChangesAsync();

            return Ok(productCalifornia);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            ProductCalifornia? productCalifornia = await context.ProductsCalifornia.FindAsync(id);

            if (productCalifornia is null)
            {
                return NotFound("Product not found in products from California.");
            }
            context.ProductsCalifornia.Remove(productCalifornia);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
