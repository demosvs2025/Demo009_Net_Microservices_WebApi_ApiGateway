using Microsoft.AspNetCore.Mvc;
using SalesBusinessAppMVC.Models;

namespace SalesBusinessAppMVC.Controllers
{
    public class ProductsNewYorkController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7076");

            List<ProductNewYork>? productsProductNewYork = new List<ProductNewYork>();
            productsProductNewYork = await httpClient.GetFromJsonAsync<List<ProductNewYork>>("/api/ProductNewYork");

            if (productsProductNewYork is not null)
            {
                return View(productsProductNewYork);
            }

            return View();
        }
    }
}
