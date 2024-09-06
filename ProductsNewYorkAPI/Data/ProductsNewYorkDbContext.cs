using Microsoft.EntityFrameworkCore;
using ProductsNewYorkAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsNewYorkAPI.Data
{
    public class ProductsNewYorkDbContext : DbContext
    {
        public ProductsNewYorkDbContext(DbContextOptions<ProductsNewYorkDbContext> options) : base(options)
        {
        }
        public DbSet<ProductNewYork> ProductsNewYork { get; set; }
    }
}
