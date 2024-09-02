using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCaliforniaAPI.Data;
using ProductsCaliforniaAPI.Models;

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
        public ActionResult<List<ProductCalifornia>> GetProductsCalifornia()
        {
            return Ok(context.ProductsCalifornia.ToList());
        }
    }
}
