using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<ProductNewYork>> GetProductsNewYork()
        {
            return Ok(context.ProductsNewYork.ToList());
        }
    }
}
