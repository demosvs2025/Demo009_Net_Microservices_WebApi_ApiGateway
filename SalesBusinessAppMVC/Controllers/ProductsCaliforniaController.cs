using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesBusinessAppMVC.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalesBusinessAppMVC.Controllers
{
    public class ProductsCaliforniaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7076");
            
            List<ProductCalifornia>? productsCalifornia = new List<ProductCalifornia>();
            productsCalifornia = await httpClient.GetFromJsonAsync<List<ProductCalifornia>>("/api/ProductCalifornia");

            if (productsCalifornia is not null) 
            {
                return View(productsCalifornia);
            }

            return View();
        }
    }
}
