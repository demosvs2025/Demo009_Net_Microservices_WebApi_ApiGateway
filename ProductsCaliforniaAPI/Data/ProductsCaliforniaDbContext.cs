﻿using Microsoft.EntityFrameworkCore;
using ProductsCaliforniaAPI.Models;

namespace ProductsCaliforniaAPI.Data
{
    public class ProductsCaliforniaDbContext : DbContext
    {
        public ProductsCaliforniaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductCalifornia> ProductsCalifornia { get; set; }
    }
}
