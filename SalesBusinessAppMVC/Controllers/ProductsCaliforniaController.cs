using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SalesBusinessAppMVC.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCaliforniaDto productCaliforniaDto)
        {
            if (ModelState.IsValid)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7076");

                var response = await httpClient.PostAsJsonAsync<ProductCaliforniaDto>("/api/ProductCalifornia", productCaliforniaDto);

                var responseBody = await response.Content.ReadAsStringAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productCaliforniaDto);
        }
                    
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7076");

            ProductCalifornia? productCalifornia;
            productCalifornia = await httpClient.GetFromJsonAsync<ProductCalifornia>($"/api/ProductCalifornia/{id}");

            if (productCalifornia is null)
            {
                return NotFound();
            }

            return View(productCalifornia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ProductCalifornia productCalifornia)
        {
            if (ModelState.IsValid)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7076");

                var response = await httpClient.PutAsJsonAsync<ProductCalifornia>($"/api/ProductCalifornia/{id}", productCalifornia);

                var responseBody = await response.Content.ReadAsStringAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productCalifornia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductCalifornia productCalifornia)
        {
            if (productCalifornia is null)
            {
                return NotFound();
            }

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7076");

            var response = await httpClient.DeleteAsync($"/api/ProductCalifornia/{productCalifornia.ProductId}");

            return RedirectToAction(nameof(Index));
        }

    }
}
